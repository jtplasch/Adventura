using System;
using Adventura.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class LocationCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Not enough characters, please enter at least 2 or more characters.")]
        [MaxLength(100, ErrorMessage = "Too many characters, please reduce to a max length of 100 characters.")]
        public string LocationName { get; set; }
        public int AdventureId { get; set; }
    }
}
