using Adventura.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class ActivityDetail
    {
        [Display(Name = "Type of Activity")]
        public TypeOfActivity ActivityType { get; set; }
        [Display(Name = "Description")]
        public string ActivityDescription { get; set; }
        [Display(Name = "Time")]
        public int ActivityLength { get; set; }
        [Display(Name = "Cost")]
        public double ActivityCost { get; set; }
    }
}
