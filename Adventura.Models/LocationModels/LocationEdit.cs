using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class LocationEdit
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public int AdventureId { get; set; }
    }
}
