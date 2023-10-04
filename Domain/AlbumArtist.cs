using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace Domain
{
    public class AlbumArtist
    {
        [Key]
        public int AlbumArtistId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int ArtistId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int AlbumId { get; set; }

        public string AlbumTitle{ get; set; }
        public string ArtistName { get; set; }
    }
}
