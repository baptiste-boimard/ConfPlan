
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var visiteurId = Guid.NewGuid();
        var adminId = Guid.NewGuid();
        var sponsorId = Guid.NewGuid();

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = visiteurId, RoleName = "Visiteur" },
            new Role { Id = adminId, RoleName = "Admin" },
            new Role { Id = sponsorId, RoleName = "Sponsor" }
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
    }
}