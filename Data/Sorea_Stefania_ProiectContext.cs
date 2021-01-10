using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sorea_Stefania_Proiect.Models;

namespace Sorea_Stefania_Proiect.Data
{
    public class Sorea_Stefania_ProiectContext : DbContext
    {
        public Sorea_Stefania_ProiectContext (DbContextOptions<Sorea_Stefania_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Sorea_Stefania_Proiect.Models.Character> Character { get; set; }

        public DbSet<Sorea_Stefania_Proiect.Models.Anime> Anime { get; set; }

        public DbSet<Sorea_Stefania_Proiect.Models.VoiceActor> VoiceActor { get; set; }
    }
}
