using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("Event")]
        #nullable enable
        public string? EventId { get; set; } // reference to the event Model
        #nullable disable
        public Event Event { get; set; }

        
        [Required]
        [ForeignKey("User")]
        #nullable enable
        public string? UserId { get; set; }
        #nullable disable
        public User User { get; set; }
    }
}