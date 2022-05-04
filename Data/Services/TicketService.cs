using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using TheKangaroos_ClubEnrolmentPortal.ExternalServices;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public TicketService(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public Ticket GetAllUserTicketsAsync(string id)
        {
            return _context.Tickets.Include(e => e.User).Where(e => e.UserId == id).FirstOrDefault();
        }

        public List<Event> GetEventsFromUserTicketsAsync(string userId)
        {
            List<Event> allEvents = new List<Event>();
            List<Ticket> tickets = _context.Tickets.Where(e => e.UserId == userId).ToList();
            foreach (Ticket ticket in tickets)
            {
                allEvents.AddRange(_context.Events.Where(e => e.Id == ticket.EventId).ToList());
            }
            
            return allEvents;
        }

        public Ticket GetTicketsAsync()
        {
            return _context.Tickets.FirstOrDefault();
        }

        public bool HasTicket(string userId, string eventId)
        {
            return _context.Tickets.Any(e => e.UserId == userId && e.EventId == eventId);
        }

        public Ticket CreateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            // send email to user
            _emailSender.SendEmailAsync(ticket.User.Email, "Ticket Confirmation",
                $"Dear {ticket.User.UserName},\n\n" +
                $"Your ticket has been created for {ticket.Event.Name}.\n\n" +
                $"Please note that your ticket number is {ticket.Id}.\n\n" +
                $"Thank you for your support.\n\n" +
                $"The Kangaroos Club");
            return ticket;
        }
    }
}