using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Nationality
    {
        [Key]
        public int NationalityId { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Nationality cannot be longer than 70 characters."), MinLength(1, ErrorMessage = "Nationality cannot be shorter than 4 characters.")]
        public string NationalityName { get; set; }
    }
}
