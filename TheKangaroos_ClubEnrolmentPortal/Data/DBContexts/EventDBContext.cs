using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheKangaroos_ClubEnrolmentPortal.Data.Migrations;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.DbContexts
{
    public class EventOperations
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public EventOperations(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public readonly Event trialEventData = new Event {
            Name = "Trial Event",
            Description = "This is a trial event",
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 1),
            Location = "Trial Location",
            Image = "Trial Image",
        };

        #region AddEvent
        public void AddEvent(Event newEvent)
        {
            using (var db = _contextFactory.CreateDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            
            using (var db = _contextFactory.CreateDbContext())
            {
                db.Events.Add(newEvent);
                db.SaveChanges();
            }
        }
        #endregion

        #region GetEvent
        public Event GetEvent(int id)
        {
            using (var db = _contextFactory.CreateDbContext())
            {
                return db.Events.Find(id);
            }
        }

        public Event GetEvent(string name)
        {
            using (var db = _contextFactory.CreateDbContext())
            {
                return db.Events.FirstOrDefault(e => e.Name == name);
            }
        }

        public List<Event> GetEvents()
        {
            using (var db = _contextFactory.CreateDbContext())
            {
                return db.Events.ToList();
            }
        }

        #endregion

        #region UpdateEvent

        public void UpdateEvent(Event updatedEvent)
        {
            using (var db = _contextFactory.CreateDbContext())
            {
                db.Entry(updatedEvent).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        #endregion

        #region DeleteEvent

        public void DeleteEvent(int id)
        {
            using (var db = _contextFactory.CreateDbContext())
            {
                var eventToDelete = db.Events.Find(id);
                db.Events.Remove(eventToDelete);
                db.SaveChanges();
            }
        }

        #endregion
    }
}