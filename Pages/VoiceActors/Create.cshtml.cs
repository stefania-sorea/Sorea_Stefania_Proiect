using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sorea_Stefania_Proiect.Data;
using Sorea_Stefania_Proiect.Models;

namespace Sorea_Stefania_Proiect.Pages.VoiceActors
{
    public class CreateModel : PageModel
    {
        private readonly Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext _context;

        public CreateModel(Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VoiceActor VoiceActor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VoiceActor.Add(VoiceActor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
