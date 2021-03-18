using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class AdventureCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "You have reached the character limit.")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "You have reached the character limit.")]
        public string Description { get; set; }                       
    }
}
