using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    public class Club
    { 
        [Key]
        public string Id { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "You must enter a valid club name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<Membership> Members { get; set; }

        public ICollection<Event> Events { get; set; }
    }

    public class ClubCreation : Club { }

    public class ClubEdit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "You must enter a valid club name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; } // reference to owner of the club - User Model
    }

    public class QueryClub
    {
        public int Id { get; set; }
    }

    // query for clubs owned by a user
    public class QueryClubs
    {
        public string UserId { get; set; }
    }

    public class DeleteClub
    {
        [Required]
        public int Id { get; set; }
    }
}