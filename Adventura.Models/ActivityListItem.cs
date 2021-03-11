using Adventura.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class ActivityListItem
    {
        public TypeOfActivity ActivityType { get; set; }
        public string ActivityDescription { get; set; }
        public int ActivityLength { get; set; }
        public double ActivityCost { get; set; }
    }
}
