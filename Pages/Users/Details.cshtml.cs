using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheKangaroos_ClubEnrolmentPortal.Data;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

namespace TheKangaroos_ClubEnrolmentPortal.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public User user { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
