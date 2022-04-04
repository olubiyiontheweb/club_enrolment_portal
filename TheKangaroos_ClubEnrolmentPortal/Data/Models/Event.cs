using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;


namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "You must enter a valid event name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }

        // events belong to a club and are created by the club
        [Required]
        public string CreatedByClubId { get; set; } // reference to the club Model
        [ForeignKey("CreatedByClubId")]
        public Club CreatedByClub { get; set; }
    }

    public class EventCreation { }

    public class EventEdit
    {
    }

    public class QueryEvent
    {
        public int Id { get; set; }
    }

    // query for events in a club
    public class QueryEvents
    {
    }

    public class DeleteEvent
    {
        [Required]
        public int Id { get; set; }
    }
}