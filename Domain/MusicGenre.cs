using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MusicGenre
    {
        [Key]
        public int MusicGenreId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "genre cannot be longer than 100 characters."), MinLength(2, ErrorMessage = "Genre cannot be shorter than 2 characters.")]
        public string Genre { get; set; }
    }
}
