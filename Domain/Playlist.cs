using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Title cannot be longer than 150 characters."), MinLength(1, ErrorMessage = "Title cannot be shorter than 1 character.")]
        public string Name { get; set; }
    }
}
