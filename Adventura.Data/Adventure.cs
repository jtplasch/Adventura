using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Data
{
    public class Adventure
    {
        [Key]
        public int AdventureId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "You have reached the character limit.")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "You have reached the character limit.")]
        public string Description { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
       
        public virtual List<Location> Locations { get; set; }
        
        public virtual List<Activity> Activities { get; set; }

        [ForeignKey(nameof(Users))]
        public int user_Id{ get; set; }
        public virtual  List<User> Users { get; set; }
    }
}
