using Microsoft.EntityFrameworkCore;

namespace backend.Model
{
    public class iMechanicContext : DbContext
    {

        public iMechanicContext()
        {

        }

        public iMechanicContext(DbContextOptions<iMechanicContext> options) : base(options)
        {
        }
        // create DbSets
        public virtual DbSet<User> Users { get; set; } = null;
    }
}
