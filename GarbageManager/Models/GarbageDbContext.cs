using Microsoft.EntityFrameworkCore;

namespace GarbageManager.Models
{
    public class GarbageDbContext : DbContext
    {
        public DbSet<Garbage> Garbages { get; set; }

        public GarbageDbContext(DbContextOptions<GarbageDbContext> options) : base(options)
        {

        }
    }
}
