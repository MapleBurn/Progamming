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
        public DbSet<EventWeek> EventWeeks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure one-to-many relationship: EventWeek -> PlannerEvent
            builder.Entity<EventWeek>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.PlannerEvents);
            });

            builder.Entity<PlannerEvent>(entity =>
            {
                entity.HasKey(e => e.Id);
                // Configure TimeOnly and DateOnly conversions if needed for SQLite:
                entity.Property(e => e.StartTime)
                      .HasConversion(
                          v => v.ToTimeSpan(),
                          v => TimeOnly.FromTimeSpan(v));

                entity.Property(e => e.EndTime)
                      .HasConversion(
                          v => v.ToTimeSpan(),
                          v => TimeOnly.FromTimeSpan(v));
            });
        }
    }
}