using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class AdventureCreate
    {
        [Required]
        [MaxLength(750, ErrorMessage = "You have reached the character limit.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(750, ErrorMessage = "You have reached the character limit.")]
        public string Location { get; set; }

        [MaxLength(1200, ErrorMessage = "You have reached the character limit.")]
        public string Activities { get; set; }

    }
}
