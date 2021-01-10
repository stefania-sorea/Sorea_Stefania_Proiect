using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sorea_Stefania_Proiect.Data;
using Sorea_Stefania_Proiect.Models;

namespace Sorea_Stefania_Proiect.Pages.Characters
{
    public class CreateModel : RolePageModel
    {
        private readonly Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext _context;

        public CreateModel(Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AnimeID"] = new SelectList(_context.Set<Anime>(), "ID", "AnimeName");
            var character = new Character();
            character.Roles = new List<Role>();
            PopulateAssignedRoleData(_context, character);
            return Page();
        }

        [BindProperty]
        public Character Character { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync(string[] selectedVoiceActors)
        {
            var newCharacter = new Character();
            if (selectedVoiceActors != null)
            {
                newCharacter.Roles = new List<Role>();
                foreach (var va in selectedVoiceActors)
                {
                    var roleToAdd = new Role
                    {
                        VoiceActorID = int.Parse(va)
                    };
                    newCharacter.Roles.Add(roleToAdd);
                }
            }
            if(await TryUpdateModelAsync<Character>(
                newCharacter, "Character", i => i.Name, i => i.Age, i => i.Gender, i => i.Height, i => i.HairColor, i => i.EyeColor, i => i.Anime, i=>i.AnimeID))
            {
                _context.Character.Add(newCharacter);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedRoleData(_context, newCharacter);
            return Page();
        }

        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Character.Add(Character);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        */
    }
}
