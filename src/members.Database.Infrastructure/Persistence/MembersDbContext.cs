using Microsoft.EntityFrameworkCore;
using EntityFramework.Exceptions.SqlServer;
using members.Database.Domain.Entities;

namespace members.Database.Infrastructure.Persistence
{
    public class MembersDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Party> Parties { get; set; }

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

            // suposed to define the max length or all properties ?

            modelBuilder.Entity<Member>(member =>
            {
                member.HasKey(m => m.Id);
                member.Property(m => m.Id).ValueGeneratedOnAdd();

                member.Property(m => m.HouseOfLordsId).IsRequired();
                member.HasIndex(m => m.HouseOfLordsId).IsUnique();

                member.Property(m => m.NameFullTitle).IsRequired().HasMaxLength(100);
                member.Property(m => m.MembershipStartDate).IsRequired();

                member.Property(m => m.PartyId).IsRequired(false);

                member.HasOne(m => m.Party)
                    .WithMany()     // no navigation from party to member
                    .HasForeignKey(m=>m.PartyId);

            });

            modelBuilder.Entity<Party>(party =>
            {
                party.ToTable("Parties");   // table name

                party.HasKey(p => p.PartyId);
                party.Property(p => p.PartyId).ValueGeneratedNever();

                party.Property(p => p.Name).IsRequired().HasMaxLength(100);

            });

        }

    }
}
