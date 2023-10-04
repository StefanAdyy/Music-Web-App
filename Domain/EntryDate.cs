using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntryDate
    {
        [Key]
        public int EntryDateId { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "You must enter a valid date.")]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastEntryHour { get; set; }
        
        public int Minutes { get; set; }
        public bool HasExited { get; set; }
    }
}
