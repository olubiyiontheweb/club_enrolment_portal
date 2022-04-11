using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Pages.Memberships
{
    public class DeleteModel : PageModel
    {
        private readonly TheKangaroos_ClubEnrolmentPortal.Data.ApplicationDbContext _context;

        public DeleteModel(TheKangaroos_ClubEnrolmentPortal.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membership = await _context.Memberships.FindAsync(id);

            if (Membership != null)
            {
                _context.Memberships.Remove(Membership);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
