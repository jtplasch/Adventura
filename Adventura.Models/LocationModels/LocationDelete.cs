using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class LocationDelete
    {        
        public string LocationName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }       
        public int AdventureId { get; set; }
    }
}
