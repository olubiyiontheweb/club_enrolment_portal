using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

using SendGrid;
using SendGrid.Helpers.Mail;
using System;

using clubEnrolmentPortal_TheKangaroos;
using Microsoft.Extensions.Configuration;

namespace clubEnrolmentPortal_TheKangaroos.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        private readonly IConfiguration Configuration;
        // constructor
        public EmailSender(IConfiguration configuration, IOptions<AuthEmailSendGridKeyGetter> optionsAccessor, ILogger<EmailSender> logger)
        {
            _logger = logger;

            // this will hold our sendgrid key
            Options = optionsAccessor.Value;

            Configuration = configuration;
        }

        // we only need to get the key from the secret store
        public AuthEmailSendGridKeyGetter Options { get; }

        public async Task SendEmailAsync(string email_destination, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("SendGrid key is not set.");
            }

            await Execute(Options.SendGridKey, subject, message, email_destination);
        }

        // this is the actual sendgrid code for sending the email
        private async Task Execute(string apiKey, string subject, string message, string email_destination)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Configuration["FromEmail"], Configuration["ProjectName"]),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email_destination));

            // Because of privacy issues, let's disable click tracking for now
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);
            
            // if the email was sent successfully, log it
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                _logger.LogInformation($"Email was successfully sent to {email_destination}");
            }
            else
            {
                _logger.LogError($"Email failed to send to {email_destination}");
            }
        }
    }
}