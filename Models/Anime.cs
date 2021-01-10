using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorea_Stefania_Proiect.Models
{
    public class Anime
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)] 
        public string AnimeName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DebutDate { get; set; }
        public string Genre { get; set; }
        [Range(1, 20)] 
        public int Seasons { get; set; }
        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Name must be of form 'Name Name'"), Required, StringLength(50, MinimumLength = 3)]
        public string Author { get; set; }
        public string Studio { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
