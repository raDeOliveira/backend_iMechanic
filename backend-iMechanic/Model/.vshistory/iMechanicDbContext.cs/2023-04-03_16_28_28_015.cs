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

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Car>? Cars { get; set; } = null;
        public virtual DbSet<UserNote> User_Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }

}
