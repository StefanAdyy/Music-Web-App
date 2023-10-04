using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        
        [Required]
        [StringLength(150, ErrorMessage = "Title cannot be longer than 150 characters."), MinLength(1, ErrorMessage = "Title cannot be shorter than 1 character.")]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter a gender id greater or equal to 1")]
        public int GenreId { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "You must enter a valid date.")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(0.10, double.MaxValue, ErrorMessage = "You must enter a length greater or equal to 0.10 minutes.")]
        public double Length { get; set; }

        public int Likes { get; set; }
        public string Genre { get; set; }
    }
}
