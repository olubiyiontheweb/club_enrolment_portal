using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class RoleService
    {
        private readonly ApplicationDbContext _context;

        private RoleManager<IdentityRole> _roleManager;

        public RoleService(ApplicationDbContext context, RoleManager<IdentityRole> roleMgr)
        {
            _context = context;
            _roleManager = roleMgr;
        }        

        public List<IdentityRole> GetAllRolesAsync()
        {
            return _context.Roles.ToList();
        }

        public IdentityRole GetRoleByIdAsync(string id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public IdentityRole CreateRoleAsync(IdentityRole role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public IdentityRole UpdateRoleAsync(IdentityRole role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }

        public IdentityRole DeleteRoleAsync(IdentityRole role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return role;
        }

        public IdentityRole AddUserToRoleAsync(string userId, string roleId)
        {
            IdentityUser user = _context.Users.FirstOrDefault(u => u.Id == userId);
            IdentityRole role = _context.Roles.FirstOrDefault(r => r.Id == roleId);
            _context.UserRoles.Add(new IdentityUserRole<string> { UserId = userId, RoleId = roleId });
            _context.SaveChanges();
            return role;
        }

        public IdentityRole RemoveUserFromRoleAsync(string userId, string roleId)
        {
            IdentityUser user = _context.Users.FirstOrDefault(u => u.Id == userId);
            IdentityRole role = _context.Roles.FirstOrDefault(r => r.Id == roleId);
            _context.UserRoles.Remove(new IdentityUserRole<string> { UserId = userId, RoleId = roleId });
            _context.SaveChanges();
            return role;
        }

        public IdentityRole GetRoleByNameAsync(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.Name == roleName);
        }

        public IdentityRole GetRoleByNormalizedNameAsync(string normalizedName)
        {
            return _context.Roles.FirstOrDefault(r => r.NormalizedName == normalizedName);
        }
    }
}