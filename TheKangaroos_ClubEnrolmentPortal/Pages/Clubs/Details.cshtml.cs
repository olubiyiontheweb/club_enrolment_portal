using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Pages.Clubs
{
    public class DetailsModel : PageModel
    {
        private readonly TheKangaroos_ClubEnrolmentPortal.Data.ApplicationDbContext _context;

        public DetailsModel(TheKangaroos_ClubEnrolmentPortal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Club Club { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club = await _context.Clubs.FirstOrDefaultAsync(m => m.Id == id);

            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
