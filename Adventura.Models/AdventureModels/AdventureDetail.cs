using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class AdventureDetail
    {
        
        public int AdventureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        public List<int> LocationIds { get; set; } = new List<int>();
        public List<int> ActivityIds { get; set; } = new List<int>();

        public List<string> LocationNames { get; set; } = new List<string>();
        public List<string> ActivityDescriptions { get; set; } = new List<string>();
    }
}
