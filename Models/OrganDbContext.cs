using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class OrganDbContext : DbContext
    {
        public OrganDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }


        public DbSet<Member> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Membership> Memberships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var DefaultOrganizationData = new List<Organization> {
            new Organization{oID = 1,
            oName = "Apple",
            oDomain="apple.com"}
            };


            modelBuilder.Entity<Organization>(e =>
            {
                e.HasKey(e => e.oID);
                e.Property(e => e.oName).HasMaxLength(50).IsRequired();
                e.Property(e => e.oDomain).HasMaxLength(50).IsRequired();

                e.HasData(DefaultOrganizationData);
                e.ToTable("Organization");

            });

            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(e => e.teamID);
                e.Property(e => e.teamName).HasMaxLength(50).IsRequired();
                e.Property(e => e.teamDescription).HasMaxLength(50).IsRequired();

                e.HasOne(e => e.Organization)
                .WithMany(e => e.teams)
                .HasForeignKey(e => e.oID)
                .OnDelete(DeleteBehavior.ClientCascade);

                e.ToTable("Team");
            });

            modelBuilder.Entity<File>(e =>
            {
                e.HasKey(e => new {e.fileID,e.teamID});
                e.Property(e => e.fileName).HasMaxLength(50).IsRequired();
                e.Property(e => e.fileExtension).HasMaxLength(50).IsRequired();
                e.Property(e => e.fileSize).IsRequired();

                e.HasOne(e => e.Team)
                .WithMany(e => e.Files)
                .HasForeignKey(e => e.teamID)
                .OnDelete(DeleteBehavior.ClientCascade);

                e.ToTable("File");
                
            });

            modelBuilder.Entity<Member>(e =>
            {
                e.HasKey(e => e.memberID);
                e.Property(e => e.memberName).HasMaxLength(50).IsRequired();
                e.Property(e => e.memberNickname).HasMaxLength(50).IsRequired();
                e.Property(e => e.memberSurname).HasMaxLength(50).IsRequired();

                e.HasOne(e => e.Organization)
                .WithMany(e => e.members)
                .HasForeignKey(e => e.oID)
                .OnDelete(DeleteBehavior.ClientCascade);

                e.ToTable("Member");
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.HasKey(e => new { e.memberID, e.teamID });
                e.Property(e => e.MembershipDate).IsRequired();

                e.HasOne(e=>e.Member)
                .WithMany(e=>e.Memberships)
                .HasForeignKey(e=>e.memberID)
                .OnDelete(DeleteBehavior.ClientCascade);

                e.HasOne(e=>e.Team)
                .WithMany(e=>e.Memberships)
                .HasForeignKey(e => e.teamID)
                .OnDelete(DeleteBehavior.ClientCascade);

                e.ToTable("Membership");
            });


        }
    }
}
