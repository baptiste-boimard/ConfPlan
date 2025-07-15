
using ConfPlan.Shared;
using Microsoft.EntityFrameworkCore;

namespace Service.OAuth.Database;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Conference> Conferences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var visiteurId = Guid.NewGuid();
        var adminId = Guid.NewGuid();
        var sponsorId = Guid.NewGuid();
        var adminUserId = Guid.NewGuid();


        modelBuilder.Entity<Role>().HasData(
            new Role { Id = visiteurId, RoleName = "Visiteur" },
            new Role { Id = adminId, RoleName = "Admin" },
            new Role { Id = sponsorId, RoleName = "Sponsor" }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = adminUserId,
                Email = "admin@confplan.dev",
                Password = "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq",
                IdRole = adminId
            }
        );
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Email).IsRequired();
            entity.Property(a => a.Password).IsRequired();
            entity.Property(a => a.IdRole).IsRequired();
            
            entity.HasOne(a => a.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(a => a.IdRole)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.RoleName).IsRequired();
        });
        
        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Day).IsRequired();
            entity.Property(a => a.TimeSlot).IsRequired();
            entity.Property(a => a.Title).IsRequired();
            entity.Property(a => a.Description).IsRequired();
            entity.Property(a => a.SpeakerName).IsRequired();
            entity.Property(a => a.SpeakerBio).IsRequired();
            entity.Property(a => a.SpeakerPhotoUrl).IsRequired();
        });
    }
}