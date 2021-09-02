using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Web_Client.Database
{
    public class ResourceContext : DbContext
    {
        public DbSet<Resurs> resursi { get; set; }
        public DbSet<Tip> tipovi { get; set; }
        public DbSet<Veza> veze { get; set; }
        public DbSet<TipVeze> tipovi_veze { get; set; }


    }
}
