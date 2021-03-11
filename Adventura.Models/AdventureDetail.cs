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
        public string Location { get; set; }        
        public string Activities { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
