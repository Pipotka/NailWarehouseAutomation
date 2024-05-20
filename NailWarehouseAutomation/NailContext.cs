using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailWarehouseAutomation
{
    class NailContext : DbContext
    {
        public NailContext()
            :base("DbConnection")
        { }

        public DbSet<Models.Nail> Nails { get; set; }
    }
}
