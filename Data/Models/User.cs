using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;

using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{   
    // Todo: remember to inherit from the identity user class
    public class User: IdentityUser
    {
        [StringLength(50, ErrorMessage ="First Name too long, please reduce")]
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name too long, please reduce")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [PersonalData]
        public string LastName { get; set; }

        // concatenate first and last name
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        [DataType(DataType.DateTime)]
        [PersonalData]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [PersonalData]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        // users can be members of multiple clubs        
        public ICollection<Membership> Memberships {get; set;}

        public ICollection<Notice> Notices {get; set;} 

        public ICollection<Ticket> Tickets {get; set;}

        // public ICollection<Attendee> Attendees {get; set;}

        public bool IsAdmin { get; set; } = false;
    }

    public class UserRegister {
        [StringLength(50, ErrorMessage ="First Name too long, please reduce")]
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [PersonalData]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last Name too long, please reduce")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [PersonalData]
        public string LastName { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        [DataType(DataType.DateTime)]
        [PersonalData]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [PersonalData]
        [DataType(DataType.Text)]
        public string Gender { get; set; }
    }
}

