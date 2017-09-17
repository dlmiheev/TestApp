using Microsoft.EntityFrameworkCore;

namespace TestApp.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(m => new { m.Name, m.Email })
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }

    }
}
