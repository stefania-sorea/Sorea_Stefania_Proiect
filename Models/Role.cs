using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorea_Stefania_Proiect.Models
{
    public class Role
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int VoiceActorID { get; set; }
        public VoiceActor VoiceActor { get; set; }
    }
}
