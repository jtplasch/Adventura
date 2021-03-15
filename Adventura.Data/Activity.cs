using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Data
{
    public enum TypeOfActivity
    {
        Biking,
        Canoe,
        Climbing,
        Fishing,
        Hiking,
        Kayak,
        Parks,
        Restaurants
    }
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        public TypeOfActivity ActivityType { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ActivityDescription { get; set; }

        public int ActivityLength { get; set; }

        public double ActivityCost { get; set; }
    }
}
