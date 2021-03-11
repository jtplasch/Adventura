using System;
using System.Collections.Generic;
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
    public class Activities
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public TypeOfActivity ActivityType { get; set; }
        
        public string Description { get; set; }
        
        public int Length { get; set; }

        public double Cost { get; set; }

    }
}
