using Adventura.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class ActivityCreate
    {
        [Required]
        public TypeOfActivity ActivityType { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ActivityDescription { get; set; }
        public int ActivityLength { get; set; }
        public double ActivityCost { get; set; }
        public int AdventureId { get; set; }
    }
}
