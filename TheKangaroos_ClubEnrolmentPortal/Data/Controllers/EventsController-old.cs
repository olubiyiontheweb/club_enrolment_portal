using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheKangaroos_ClubEnrolmentPortal.Data;
using TheKangaroos_ClubEnrolmentPortal.Data.Migrations;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Controllers
{
    public class EventsControllerold : Controller
    {
        //private readonly ApplicationDbContext _context;

        public readonly Event trialEventData = new Event
        {
            Name = "Trial Event",
            Description = "This is a trial event",
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 1),
            Location = "Trial Location",
            Image = "Trial Image",
        };

    }
}