using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Pages.Memberships
{
    public class EditModel : PageModel
    {
        private readonly TheKangaroos_ClubEnrolmentPortal.Data.ApplicationDbContext _context;

        public EditModel(TheKangaroos_ClubEnrolmentPortal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Membership Membership { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membership = await _context.Memberships
                .Include(m => m.Club)
                .Include(m => m.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Membership == null)
            {
                return NotFound();
            }
           ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Membership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipExists(Membership.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MembershipExists(string id)
        {
            return _context.Memberships.Any(e => e.Id == id);
        }
    }
}
