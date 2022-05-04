using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class MembershipService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public MembershipService(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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
            return _context.Memberships.Include(e => e.Club).Include(e => e.User).Where(e => e.UserId == id && e.IsApproved == true).ToList();
        }

        public bool IsMember(string userId, string clubId)
        {
            return _context.Memberships.Any(e => e.UserId == userId && e.ClubId == clubId);
        }

        public bool IsApproved(string userId, string clubId)
        {
            return _context.Memberships.Any(e => e.UserId == userId && e.ClubId == clubId && e.IsApproved == true);
        }

        public Membership ApproveMembershipAsync(Membership @membership)
        {
            Membership member = _context.Memberships.Where(e=> e.Id == @membership.Id).FirstOrDefault();
            member.IsApproved = true;
            _context.SaveChanges();
            return @membership;
        }
        public Membership PostMembershipAsync(Membership @membership)
        {
            _context.Memberships.Add(@membership);
            _context.SaveChanges();

            // send email to user
            //_emailSender.SendEmailAsync(@membership.User.Email, "Membership Confirmation",
            //    $"Dear {@membership.User.UserName},\n\n" +
            //    $"You have been added to the {@membership.Club.Name} club.\n\n" +
            //    $"Thank you for your support.\n\n" +
            //    $"The Kangaroos Club");

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