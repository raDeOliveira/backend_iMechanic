using Microsoft.EntityFrameworkCore;

namespace backend_iMechanic.Model
{
    public class iMechanicDbContext : DbContext
    {

        public iMechanicDbContext()
        {

        }

        public iMechanicDbContext(DbContextOptions<iMechanicDbContext> options) : base(options)
        {
        }
        // create DbSets
        public virtual DbSet<User> Users { get; set; } = null;
        public virtual DbSet<Car> Cars { get; set; } = null;
        public virtual DbSet<UserNotes> UsersNotes { get; set; } = null;
    }
}
