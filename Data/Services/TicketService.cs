using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Ticket GetAllUserTicketsAsync(string id)
        {
            return _context.Tickets.Include(e => e.User).Where(e => e.UserId == id).FirstOrDefault();
        }

        public Ticket GetTicketsAsync()
        {
            return _context.Tickets.FirstOrDefault();
        }
    }
}