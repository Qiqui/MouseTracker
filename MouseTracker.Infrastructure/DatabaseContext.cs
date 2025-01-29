using Microsoft.EntityFrameworkCore;
using MouseTracker.Domain.Models;

namespace MouseTracker.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MouseMovement> MouseMovements { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
