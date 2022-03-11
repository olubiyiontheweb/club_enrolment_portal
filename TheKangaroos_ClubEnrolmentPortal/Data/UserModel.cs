using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using System.Security.Claims;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Models
{
    // Todo: remember to inherit from the identity user class
    public class User: IdentityUser
    {
        public List<Club> OwnedClubs { get; set; }
    }

    /* public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOptions<IdentityOptions> optionsAccessor
            ) : base(userManager, roleManager, optionsAccessor) 
            { 

            }


        // remove later
        public async override Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            if (user.OwnedClubs.Count > 0)
            {
                var identity = (ClaimsIdentity)principal.Identity;
                identity.AddClaim(new Claim("OwnedClubs", string.Join(",", user.OwnedClubs)));
            }

            return principal;
        }
    }

    public static class IdentityExtensions
    {
        public static string OwnedClubs(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("OwnedClubs");

            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    } */
}