using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    public class Notice
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "You must enter a valid event title")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "You must enter a valid event title")]
        public string Description { get; set; }

        public bool isAnnouncement { get; set; }
        public bool isEnquiry { get; set; }

        public string Image { get; set; }

        [Required]
        [ForeignKey("CreatedByClub")]
        #nullable enable
        public string? CreatedByClubId { get; set; } // reference to the club Model
        #nullable disable
        public Club CreatedByClub { get; set; }
    }
}