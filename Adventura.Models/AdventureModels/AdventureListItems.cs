using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Models
{
    public class AdventureListItems
    {
        public int AdventureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }        
        public List<int> LocationId { get; set; }
        public List<int> ActivityId { get; set; }
    }
}
