using Adventura.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Data
{
    public class AdventureDbContext : DbContext
    {
        public AdventureDbContext() : base("DefaultConnection") { }
        public DbSet<Adventure> Adventures { get; set; }

        //Do we want to add activities or location in here?

    }
}
