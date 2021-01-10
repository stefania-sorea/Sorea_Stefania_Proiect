using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorea_Stefania_Proiect.Models
{
    public class Character
    {
        public int ID { get; set; }

        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+$",ErrorMessage = "Name must be of form 'Name Name'"),Required, StringLength(50,MinimumLength =3)]
        [Display(Name="Character Name")]
        public string Name { get; set; }
        
        [Range(1,100)]
        public int Age { get; set; }
        public string Gender { get; set; }

        [Column(TypeName ="decimal(6,2)")]
        public decimal Height { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }

        public int AnimeID { get; set; }
        public Anime Anime { get; set; }

        [Display(Name = "Voice Actors")]
        public ICollection<Role> Roles { get; set; }
    }
}
