using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain
{
    public class PlaylistSong
    {
        [Key]
        public int PlaylistSongId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int PlaylistId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public string SongArtistName { get; set; }
    }
}
