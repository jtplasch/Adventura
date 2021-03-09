using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class AdventureListItems
    {
        [Key]
        public int AdventureId { get; set; }

        [Required]
        [MaxLength(750, ErrorMessage = "You have reached the character limit.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(750, ErrorMessage = "You have reached the character limit.")]
        public string Location { get; set; }

        [MaxLength(1200, ErrorMessage = "You have reached the character limit.")]
        public string Activities { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
