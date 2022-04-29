using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

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

        /* public Notice GetNoticesFromAllMembershipsAsync()
        {
            return _context.Notices.not
        } */

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