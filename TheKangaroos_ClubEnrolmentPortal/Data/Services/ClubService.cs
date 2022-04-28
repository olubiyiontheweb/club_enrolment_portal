using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class ClubService
    {
        private readonly ApplicationDbContext _context;

        public ClubService(ApplicationDbContext context)
        {
            _context = context;
        }    

        public List<Club> GetClubsAsync()
        {
            return _context.Clubs.ToList();
        }

        public Club GetClubByIdAsync(string id)
        {
            return _context.Clubs.FirstOrDefault(c => c.Id == id);
        }

        public Club PostClubAsync(Club club)
        {
            _context.Clubs.Add(club);
            _context.SaveChanges();
            return club;
        }

        public Club PutClubAsync(Club club)
        {
            _context.Clubs.Update(club);
            _context.SaveChanges();
            return club;
        }

        public List<Event> GetEventsByClubIdAsync(string id)
        {
            return _context.Events.Where(e => e.CreatedByClubId == id).ToList();
        }
    }
}
