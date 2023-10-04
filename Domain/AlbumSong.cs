using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AlbumSong
    {
        [Key]
        public int AlbumSongId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int AlbumId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int SongId { get; set; }

        public string AlbumTitle { get; set; }
        public string SongTitle { get; set; }
    }
}
