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
    public class MembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Memberships
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Memberships.Include(m => m.Club).Include(m => m.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Memberships/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .Include(m => m.Club)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: Memberships/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ClubId")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Id", membership.ClubId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", membership.UserId);
            return View(membership);
        }

        // GET: Memberships/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Id", membership.ClubId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", membership.UserId);
            return View(membership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserId,ClubId")] Membership membership)
        {
            if (id != membership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipExists(membership.Id))
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
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Id", membership.ClubId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", membership.UserId);
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .Include(m => m.Club)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipExists(string id)
        {
            return _context.Memberships.Any(e => e.Id == id);
        }
    }
}
