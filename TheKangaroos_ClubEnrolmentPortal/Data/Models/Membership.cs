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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } //= Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("User")]
        #nullable enable
        public string? UserId { get; set; } // reference to the user Model   
        #nullable disable     
        public User User { get; set; }

        [Required]
        [ForeignKey("Club")]
        #nullable enable 
        public string? ClubId { get; set; } // reference to the club Model
        #nullable disable
        public Club Club { get; set; }
    }
}