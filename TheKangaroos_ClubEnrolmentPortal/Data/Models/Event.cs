using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // = Guid.NewGuid().ToString();

        [Required]
        [StringLength(250, ErrorMessage = "You must enter a valid event name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        
        public string Image { get; set; }

        //public Venue Venue { get; set; }

        // events belong to a club and are created by the club
        [Required]
        [ForeignKey("CreatedByClub")]
        #nullable enable
        public string? CreatedByClubId { get; set; } // reference to the club Model
        #nullable disable
        public Club CreatedByClub { get; set; }
    }
}