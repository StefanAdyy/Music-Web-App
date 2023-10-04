using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="First name cannot be longer than 100 characters."), MinLength(3, ErrorMessage = "First name cannot be shorter than 3 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Second name cannot be longer than 100 characters."), MinLength(3, ErrorMessage = "Second name cannot be shorter than 3 characters.")]
        public string SecondName { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "You must enter a valid date.")]
        public DateTime Birthdate { get; set; }

        [Required]
        [RegularExpression("male|Male|MALE|female|Female|FEMALE", ErrorMessage = "You must enter a valid gender.")]
        public string Gender { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter valid integer number greater than 0.")]
        public int NationalityId { get; set; }

        public string Nationality { get; set; }
    }
}
