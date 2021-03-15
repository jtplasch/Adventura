using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class LocationDelete
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset EditUtc { get; set; }
        public int AdventureId { get; set; }
    }
}
