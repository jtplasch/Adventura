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
        public int LocationId { get; set; }

        [MaxLength(1200, ErrorMessage = "You have reached the character limit.")]
        public int ActivityId { get; set; }

        public int user_Id { get; set; }

    }
}
