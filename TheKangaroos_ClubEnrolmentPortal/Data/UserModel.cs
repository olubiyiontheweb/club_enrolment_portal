using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.Security.Claims;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    // Todo: remember to inherit from the identity user class
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Club> OwnedClubs { get; set; }
        public string ProfilePicture { get; set; }
    }
}