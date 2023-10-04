using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Title cannot be longer than 150 characters."), MinLength(1, ErrorMessage = "Title cannot be shorter than 1 character.")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "You must enter a valid date.")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Record label cannot be longer than 100 characters."), MinLength(2, ErrorMessage = "Record label cannot be shorter than 2 characters.")]
        public string RecordLabel { get; set; }
    }
}
