using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class ActivityListItem
    {
        public int ActivityId { get; set; }

        public TypeOfActivity ActivityType { get; set; }

        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ActivityDescription { get; set; }
    }
}
