using Microsoft.EntityFrameworkCore;

namespace backend_iMechanic.Model
{
    public class iMechanicDbContext : DbContext
    {
        public iMechanicDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }

    }
}
