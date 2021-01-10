using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorea_Stefania_Proiect.Models
{
    public class CharacterData
    {
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<VoiceActor> VoiceActors { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
