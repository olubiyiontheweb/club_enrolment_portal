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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "You must enter a valid event title")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "You must enter a valid event title")]
        public string Description { get; set; }

        // true when created by user
        public bool isAnnouncement { get; set; } = false;
        public bool isEnquiry { get; set; } = true;

        public string Image { get; set; }

        // used for clubs sending announcements to members
        [ForeignKey("CreatedByClub")]
        #nullable enable
        public string? CreatedByClubId { get; set; } // reference to the club Model
        #nullable disable
        public Club CreatedByClub { get; set; }

        // for users to send enquiries or announcements
        [Required]
        [ForeignKey("CreatedByUser")]
        #nullable enable
        public string? CreatedByUserId { get; set; } // reference to the user Model
        #nullable disable
        public User CreatedByUser { get; set; }
    }
}