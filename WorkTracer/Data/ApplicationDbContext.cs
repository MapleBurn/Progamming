using Microsoft.EntityFrameworkCore;

namespace WorkTracer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlannerEvent> PlannerEvents { get; set; }
        public DbSet<UserRecord> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });
            
            builder.Entity<PlannerEvent>(entity =>
            {
                entity.HasKey(e => e.Id);
                // Configure TimeOnly and DateOnly conversions if needed for SQLite:
                entity.HasOne<UserRecord>(e => e.Owner);
            });
            
        }
    }
}