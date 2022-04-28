using System;
using System.Linq;
using System.Collections.Generic;
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

        public List<Event> GetEventsAsync()
        {
            return _context.Events.Include(e => e.CreatedByClub).ToList();
        }

        public Event GetEventByIdAsync(string id)
        {
            return _context.Events.Include(e => e.CreatedByClub).FirstOrDefault(e => e.Id == id);
        }

        public Event PostEventAsync(Event @event)
        {
            _context.Events.Add(@event);
            _context.SaveChanges();
            return @event;
        }

        public Event PutEventAsync(Event @event)
        {
            _context.Events.Update(@event);
            _context.SaveChanges();
            return @event;
        }

        public Event DeleteEventAsync(Event @event)
        {
            _context.Events.Remove(@event);
            _context.SaveChanges();
            return @event;
        }
    }
}
