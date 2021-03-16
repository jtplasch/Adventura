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
        DiscGolfing,
        Fishing,
        Golfing,
        Hiking,
        Kayak,
        Parks,
        Restaurants
    }
    public class Activity
    {
        [Key]
        [Display(Name = "Id")]
        public int ActivityId { get; set; }

        [Required]
        [Display(Name = "Type")]
        public TypeOfActivity ActivityType { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Description")]
        public string ActivityDescription { get; set; }
        [Display(Name = "Time")]
        public int ActivityLength { get; set; }
        [Display(Name = "Cost")]
        public double ActivityCost { get; set; }
    }
}
