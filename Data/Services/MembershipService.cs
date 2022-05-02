using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class MembershipService
    {
        private readonly ApplicationDbContext _context;

        public MembershipService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Membership> GetMembershipsAsync()
        {
            return _context.Memberships.ToList();
        }

        public List<Membership> GetMembersByClubIdAsync(string id)
        {
            return _context.Memberships.Include(e => e.Club).Include(e => e.User).Where(e => e.ClubId == id).ToList();
        }

        public List<Membership> GetClubsByUserIdAsync(string id)
        {
            return _context.Memberships.Include(e => e.Club).Include(e => e.User).Where(e => e.UserId == id).ToList();
        }

        public bool IsMember(string userId, string clubId)
        {
            return _context.Memberships.Any(e => e.UserId == userId && e.ClubId == clubId);
        }
        public Membership PostMembershipAsync(Membership @membership)
        {
            _context.Memberships.Add(@membership);
            _context.SaveChanges();
            return @membership;
        }

        public Membership PutMembershipAsync(Membership @membership)
        {
            _context.Memberships.Update(@membership);
            _context.SaveChanges();
            return @membership;
        }

        public Membership DeleteMembershipAsync(Membership @membership)
        {
            _context.Memberships.Remove(@membership);
            _context.SaveChanges();
            return @membership;
        }
    }
}