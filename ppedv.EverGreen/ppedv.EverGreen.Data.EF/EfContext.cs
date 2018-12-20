using ppedv.EverGreen.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.ModelConfiguration.Conventions.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
