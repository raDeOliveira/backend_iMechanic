using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace backend_iMechanic.Model
{
    public class iMechanicDbContext : DbContext
    {
        public iMechanicDbContext()
        {
        }

        public iMechanicDbContext(DbContextOptions<iMechanicDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
