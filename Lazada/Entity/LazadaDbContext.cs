using Lazada.Models;
using Microsoft.EntityFrameworkCore;

namespace Lazada.Entity
{
    public class LazadaDbContext : DbContext
    {
        public LazadaDbContext(DbContextOptions<LazadaDbContext> options) : base(options) { }
        public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(entity => entity.IsActive)
                      .HasDefaultValue(true);
                      
            });
        }
    }
}
