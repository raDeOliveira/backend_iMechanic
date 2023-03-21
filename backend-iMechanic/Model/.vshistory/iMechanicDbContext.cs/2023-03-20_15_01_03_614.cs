using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace backend_iMechanic.Model
{
    public class iMechanicDbContext : DbContext
    {
        public iMechanicDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
