using System;
using System.Linq;
using System.Collections.Generic;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Services
{
    public class NoticeService
    {
        private readonly ApplicationDbContext _context;

        public NoticeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Notice> GetNoticesAsync()
        {
            return _context.Notices.ToList();
        }

        public List<Notice> GetNoticesFromAllUserMembershipsAsync(string userId)
        {
            List<Notice> allNotices = new List<Notice>();
            List<Membership> memberships = _context.Memberships.Where(e => e.UserId == userId).ToList();
            foreach (Membership membership in memberships)
            {
                allNotices.AddRange(_context.Notices.Where(e => e.CreatedByClubId == membership.ClubId).ToList());
            }
            
            return allNotices;
        }

        public List<Notice> GetNoticesByClubIdAsync(string id)
        {
            return _context.Notices.Include(e => e.CreatedByClub).Where(e => e.CreatedByClubId == id).ToList();
        }

        public List<Notice> GetNoticesByUserIdAsync(string id)
        {
            return _context.Notices.Include(e => e.CreatedByUser).Where(e => e.CreatedByUserId == id).ToList();
        }

        public Notice GetNoticeByIdAsync(string id)
        {
            return _context.Notices.Include(e => e.CreatedByClub).Include(e => e.CreatedByUser).Where(e => e.Id == id).FirstOrDefault();
        }

        public Notice CreateNoticeAsync(Notice @notice)
        {
            _context.Notices.Add(@notice);
            _context.SaveChanges();
            return @notice;
        }

        public Notice UpdateNoticeAsync(Notice @notice)
        {
            _context.Notices.Update(@notice);
            _context.SaveChanges();
            return @notice;
        }

        public Notice DeleteNoticeAsync(Notice @notice)
        {
            _context.Notices.Remove(@notice);
            _context.SaveChanges();
            return @notice;
        }
    }
}