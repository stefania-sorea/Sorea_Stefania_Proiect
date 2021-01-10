using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sorea_Stefania_Proiect.Data;
using Sorea_Stefania_Proiect.Models;

namespace Sorea_Stefania_Proiect.Pages.Characters
{
    public class DetailsModel : PageModel
    {
        private readonly Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext _context;

        public DetailsModel(Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext context)
        {
            _context = context;
        }

        public Character Character { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Character.FirstOrDefaultAsync(m => m.ID == id);

            if (Character == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
