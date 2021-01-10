using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sorea_Stefania_Proiect.Data;
using Sorea_Stefania_Proiect.Models;

namespace Sorea_Stefania_Proiect.Pages.VoiceActors
{
    public class EditModel : PageModel
    {
        private readonly Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext _context;

        public EditModel(Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VoiceActor VoiceActor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VoiceActor = await _context.VoiceActor.FirstOrDefaultAsync(m => m.ID == id);

            if (VoiceActor == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VoiceActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoiceActorExists(VoiceActor.ID))
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

        private bool VoiceActorExists(int id)
        {
            return _context.VoiceActor.Any(e => e.ID == id);
        }
    }
}
