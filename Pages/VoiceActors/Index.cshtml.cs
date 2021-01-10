using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sorea_Stefania_Proiect.Data;
using Sorea_Stefania_Proiect.Models;

namespace Sorea_Stefania_Proiect.Pages.VoiceActors
{
    public class IndexModel : PageModel
    {
        private readonly Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext _context;

        public IndexModel(Sorea_Stefania_Proiect.Data.Sorea_Stefania_ProiectContext context)
        {
            _context = context;
        }

        public IList<VoiceActor> VoiceActor { get;set; }

        public async Task OnGetAsync()
        {
            VoiceActor = await _context.VoiceActor.ToListAsync();
        }
    }
}
