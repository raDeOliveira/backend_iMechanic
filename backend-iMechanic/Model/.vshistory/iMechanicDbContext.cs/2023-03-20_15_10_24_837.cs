using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
