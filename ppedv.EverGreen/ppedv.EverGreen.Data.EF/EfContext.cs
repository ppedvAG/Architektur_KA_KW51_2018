using ppedv.EverGreen.Model;
using System.Data.Entity;

namespace ppedv.EverGreen.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<BaumArt> BaumArt { get; set; }
        public DbSet<Herkunft> Herkunft { get; set; }
        public DbSet<Tannenbaum> Tannenbaum { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=.;Database=EverGreen_dev;Trusted_Connection=true;")
        { }
    }
}
