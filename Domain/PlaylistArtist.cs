using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlaylistArtist
    {
        [Key]
        public int PlaylistArtistId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int PlaylistId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int ArtistId { get; set; }
    }
}
