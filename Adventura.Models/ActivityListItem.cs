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
        [MaxLength(90, ErrorMessage = "You have reached the character limit.")]
        public string Description { get; set; }
        public int PhoneNumber { get; set; }
    }
}
