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

namespace Sorea_Stefania_Proiect.Pages.Characters
{
    public class EditModel : RolePageModel
    {
        private readonly Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext _context;

        public EditModel(Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Character Character { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Character
                .Include(b=>b.Anime)
                .Include(b=>b.Roles)
                .ThenInclude(b=>b.VoiceActor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Character == null)
            {
                return NotFound();
            }

            PopulateAssignedRoleData(_context, Character);

            ViewData["AnimeID"] = new SelectList(_context.Set<Anime>(), "ID", "AnimeName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedVoiceActors)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterToUpdate = await _context.Character
                .Include(b => b.Anime)
                .Include(b => b.Roles)
                .ThenInclude(b => b.VoiceActor)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (characterToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Character>(
                characterToUpdate, "Character", i=>i.Name, i=>i.Age, i=>i.Gender, i=>i.Height, i=>i.HairColor, i=>i.EyeColor, i=>i.Anime))
            {
                UpdateRoles(_context, selectedVoiceActors, characterToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateRoles(_context, selectedVoiceActors, characterToUpdate);
            PopulateAssignedRoleData(_context, characterToUpdate);
            return Page();
            
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(Character.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.ID == id);
        }
    }
}
