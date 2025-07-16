
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
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<UserConference> UserConferences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
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
            entity.Property(a => a.IdRoom).IsRequired();
            entity.Property(a => a.Title).IsRequired();
            entity.Property(a => a.Description).IsRequired();
            entity.Property(a => a.IdSpeaker).IsRequired();
            entity.Property(a => a.Participant).IsRequired();
            
            entity.HasOne(a => a.Room)
                .WithOne(r => r.Conference)
                .HasForeignKey<Conference>(a => a.IdRoom)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(a => a.Speaker)
                .WithOne(r => r.Conference)
                .HasForeignKey<Conference>(a => a.IdSpeaker)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name).IsRequired();
            entity.Property(a => a.MaxCapacity).IsRequired();
            entity.Property(a => a.CurrentCapacity).IsRequired();
        });
        
        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name).IsRequired();
            entity.Property(a => a.Bio).IsRequired();
            entity.Property(a => a.PhotoUrl).IsRequired();
        });
        
        // modelBuilder.Entity<UserConference>(entity =>
        // {
        //     entity.HasKey(a => a.Id);
        //     entity.Property(a => a.IdUser).IsRequired();
        //     entity.Property(a => a.IdConference).IsRequired();
        //     
        //     
        // }
        
        modelBuilder.Entity<UserConference>(entity =>
        {
            entity.HasKey(uc => new { uc.IdUser, uc.IdConference }); // Composite Key

            entity.HasOne(uc => uc.User)
                .WithMany(u => u.UserConferences)
                .HasForeignKey(uc => uc.IdUser);

            entity.HasOne(uc => uc.Conference)
                .WithMany(c => c.UserConferences)
                .HasForeignKey(uc => uc.IdConference);
        });
        
        
        var visiteurId = Guid.NewGuid();
        var adminId = Guid.NewGuid();
        var sponsorId = Guid.NewGuid();
        
        var adminUserId = Guid.NewGuid();
        
        var roomAId = Guid.NewGuid(); 
        var roomBId = Guid.NewGuid(); 
        var roomCId = Guid.NewGuid(); 
        var roomDId = Guid.NewGuid(); 
        var roomEId = Guid.NewGuid(); 
        var roomFId = Guid.NewGuid(); 
        var roomGId = Guid.NewGuid(); 
        var roomHId = Guid.NewGuid(); 
        var roomIId = Guid.NewGuid(); 
        var roomJId = Guid.NewGuid(); 
        
        var speaker1Id = Guid.NewGuid();
        var speaker2Id = Guid.NewGuid();
        var speaker3Id = Guid.NewGuid();
        
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
        
        modelBuilder.Entity<Room>().HasData(
            new Room { Id = roomAId, Name = "Salle A", MaxCapacity = 20, CurrentCapacity = 0},
            new Room { Id = roomBId, Name = "Salle B", MaxCapacity = 20, CurrentCapacity = 0},
            new Room { Id = roomCId, Name = "Salle C", MaxCapacity = 10, CurrentCapacity = 0},
            new Room { Id = roomDId, Name = "Salle D", MaxCapacity = 10, CurrentCapacity = 0},
            new Room { Id = roomEId, Name = "Salle E", MaxCapacity = 5, CurrentCapacity = 0},
            new Room { Id = roomFId, Name = "Salle F", MaxCapacity = 5, CurrentCapacity = 0},
            new Room { Id = roomGId, Name = "Salle G", MaxCapacity = 50, CurrentCapacity = 0},
            new Room { Id = roomHId, Name = "Salle H", MaxCapacity = 50, CurrentCapacity = 0},
            new Room { Id = roomIId, Name = "Salle I", MaxCapacity = 100, CurrentCapacity = 0},
            new Room { Id = roomJId, Name = "Salle J", MaxCapacity = 100, CurrentCapacity = 0}
        );
        
        modelBuilder.Entity<Speaker>().HasData(
            new Speaker
            {
                Id = speaker1Id,
                Name = "Michel Dupont",
                Bio = "Le professeur Michel Dupont est un expert reconnu en Data Learning, alliant recherche académique et applications industrielles.\nIl enseigne l'intelligence artificielle et le machine learning dans plusieurs établissements de renom.\nSes travaux portent sur l’apprentissage automatique, les réseaux de neurones et les systèmes intelligents.\nIl intervient régulièrement dans des conférences pour partager ses découvertes et pratiques innovantes.\nPassionné par la transmission du savoir, il accompagne aussi des projets en transformation numérique.",
                PhotoUrl = "https://images.generated.photos/SRoJei2r0zIOyegFdcuLXagsSfVOY-G_WNLiKFIMy-g/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzMyMzU2LmpwZw.jpg"
            },
            new Speaker
            {
                Id = speaker2Id,
                Name = "Victoria Martin",
                Bio = "Victoria Martin est une spécialiste de l’UI/UX avec plus de 10 ans d’expérience dans la conception centrée utilisateur.\nElle accompagne des entreprises innovantes dans la création d’interfaces intuitives et engageantes.\nSon approche allie design émotionnel, accessibilité et performance.\nElle intervient régulièrement en conférences pour partager sa vision du design éthique et durable.\nVictoria est également mentor pour de jeunes designers qu’elle forme aux meilleures pratiques du secteur.",
                PhotoUrl = "https://images.generated.photos/BAGgXKAepAIfdaVT-GQ2CMaXys3XZ5qdTVIqL1XFN2E/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODE3MTI0LmpwZw.jpg"
            },
            new Speaker
            {
                Id = speaker3Id,
                Name = "Albert MetalStein",
                Bio = "Albert MetalStein est un expert visionnaire en physique des métaux et matériaux avancés.\nSes recherches repoussent les limites de la conductivité, de la résistance et de la transformation des alliages.\nIl est reconnu pour ses travaux sur les propriétés quantiques des structures métalliques.\nConférencier passionné, il vulgarise la science du métal avec précision et énergie.\nAlbert collabore avec des laboratoires et industries à la pointe de l’innovation métallurgique.",
                PhotoUrl = "https://images.generated.photos/IlHIAAkLdeOdb8dHl4uHy7neqz3DgWD4tE7PcqCGzz4/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NTMyNzc5LmpwZw.jpg"
            }
        );
    }
}