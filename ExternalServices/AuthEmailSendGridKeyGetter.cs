namespace TheKangaroos_ClubEnrolmentPortal.ExternalServices
{
    public class AuthEmailSendGridKeyGetter
    {
        // this is a reference to the SendGrid key in the user secrets
        #nullable enable
        public string? SendGridKey { get; set; }
    }
}