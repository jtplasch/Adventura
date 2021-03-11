using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Data
{
    public class Adventure
    {
        [Key]
        public int AdventureId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(750, ErrorMessage = "You have reached the character limit.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Enter the City/State this adventure took place:")]
        public string Location { get; set; }
        [MaxLength(750, ErrorMessage = "You have reached the character limit.")]
        [Display(Name = "Enter activities and places of interest you visited:")]
        public string Activities { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
