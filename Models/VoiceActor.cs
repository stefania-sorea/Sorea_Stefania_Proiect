using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorea_Stefania_Proiect.Models
{
    public class VoiceActor
    {
        public int ID { get; set; }

        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Name must be of form 'Name Name'"), Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Language { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
