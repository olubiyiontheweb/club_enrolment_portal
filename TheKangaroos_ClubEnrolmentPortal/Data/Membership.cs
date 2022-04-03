using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    public class Membership
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; } // reference to the user Model
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string ClubId { get; set; } // reference to the club Model
        [ForeignKey("ClubId")]
        public Club Club { get; set; }
    }
}