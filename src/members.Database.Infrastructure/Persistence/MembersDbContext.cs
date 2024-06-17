using Microsoft.EntityFrameworkCore;
using EntityFramework.Exceptions.SqlServer;
using members.Database.Domain.Entities;

namespace members.Database.Infrastructure.Persistence
{
    public class MembersDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public MembersDbContext(DbContextOptions<MembersDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseExceptionProcessor();
            }

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>(member =>
            {
                member.HasKey(m => m.Id);
                member.Property(m => m.LastName).IsRequired().HasMaxLength(100);
            });

        }

    }
}
