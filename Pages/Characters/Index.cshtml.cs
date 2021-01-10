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
    public class IndexModel : PageModel
    {
        private readonly Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext _context;

        public IndexModel(Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; }
        public CharacterData CharacterD { get; set; }
        public int CharacterID { get; set; }
        public int VoiceActorID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CharacterD = new CharacterData();
            CharacterD.Characters = await _context.Character
                .Include(b => b.Anime)
                .Include(b => b.Roles)
                .ThenInclude(b => b.VoiceActor)
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ToListAsync();
            if (id != null)
            {
                CharacterID = id.Value;
                Character character = CharacterD.Characters.Where(i => i.ID == id.Value).Single();
                CharacterD.VoiceActors = character.Roles.Select(s => s.VoiceActor);
            }
        }
        /*public async Task OnGetAsync()
        {
            Character = await _context.Character.Include(c=>c.Anime).ToListAsync();
        }*/
    }
}
