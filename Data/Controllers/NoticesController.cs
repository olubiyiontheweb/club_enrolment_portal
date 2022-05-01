using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Controllers
{
    public class NoticesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoticesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Notices.Include(n => n.CreatedByClub).Include(n => n.CreatedByUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .Include(n => n.CreatedByClub)
                .Include(n => n.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            ViewData["CreatedByClubId"] = new SelectList(_context.Clubs, "Id", "Id");
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,isAnnouncement,isEnquiry,Image,CreatedByClubId,CreatedByUserId")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedByClubId"] = new SelectList(_context.Clubs, "Id", "Id", notice.CreatedByClubId);
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", notice.CreatedByUserId);
            return View(notice);
        }

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            ViewData["CreatedByClubId"] = new SelectList(_context.Clubs, "Id", "Id", notice.CreatedByClubId);
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", notice.CreatedByUserId);
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Description,isAnnouncement,isEnquiry,Image,CreatedByClubId,CreatedByUserId")] Notice notice)
        {
            if (id != notice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeExists(notice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedByClubId"] = new SelectList(_context.Clubs, "Id", "Id", notice.CreatedByClubId);
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", notice.CreatedByUserId);
            return View(notice);
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .Include(n => n.CreatedByClub)
                .Include(n => n.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var notice = await _context.Notices.FindAsync(id);
            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeExists(string id)
        {
            return _context.Notices.Any(e => e.Id == id);
        }
    }
}
