using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class AdventureEdit
    {
        public int AdventureId { get; set; }
        public string Title { get; set; }
        public int LocationId { get; set; }
        public int ActivityId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
