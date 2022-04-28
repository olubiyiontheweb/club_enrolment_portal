using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Club[]> GetClubs()
        {
            Club[] clubs = await _context.Clubs.ToArrayAsync();
            return clubs;
        }
        
        /* 
        {
            return _context.Clubs.In
            #var applicationDbContext = _context.Events.Include(e => e.CreatedByClub);                      
            #return await applicationDbContext.ToArrayAsync();
        } */
    }
}
