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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } //= Guid.NewGuid().ToString();
        
        [Required]
        [StringLength(50, ErrorMessage = "You must enter a valid club name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Boolean IsApproved { get; set; } = false;

        public ICollection<Membership> Members { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<Notice> Notices { get; set; }
    }
}