using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    public class Venue
    {
        [Key]
        public string Id { get; set; }
    }
}