﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adventura.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        
        [Required]
        public string LocationName { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset EditUtc { get; set; }

        [Required]
        [ForeignKey(nameof(Adventure))]
        public int AdventureId { get; set; }
    }
}
