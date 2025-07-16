
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
                .WithMany(r => r.Conferences)
                .HasForeignKey(a => a.IdRoom)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(a => a.Speaker)
                .WithMany(r => r.Conferences)
                .HasForeignKey(a => a.IdSpeaker)
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
        
        
        var visiteurId = new Guid("8a738c4e-9c30-48d2-9817-f59a657e529c");
        var adminId = new Guid("d5ab69c2-4b14-4a15-8a90-1b3a86eb8aa2");
        var sponsorId = new Guid("a3fef80b-2b2e-46d1-a88e-123d0d7a7615");
        
        var adminUserId = new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd");
        
        var roomAId = new Guid("23e25c37-1d79-45f2-b0d5-8f7f4144525c"); 
        var roomBId = new Guid("16d87d5d-6c25-448c-9bb9-65b0a7c2e729"); 
        var roomCId = new Guid("5bcbef3c-9790-4032-84c2-3b0706464b6f"); 
        var roomDId = new Guid("0f29a8cb-4931-4b60-9473-fd2a3932e2d3"); 
        var roomEId = new Guid("7dc3d927-2f26-4c39-bdd2-4b6e17b7d0ac"); 
        var roomFId = new Guid("d4fd6f46-7788-4f78-a79a-2f0a5f8c2e7e"); 
        var roomGId = new Guid("902beee3-83f5-48c6-8b5b-2214e03bdb20"); 
        var roomHId = new Guid("f203c2a4-69b7-43ee-8133-547b1928a99a"); 
        var roomIId = new Guid("2aa6be59-5803-4de3-b7f3-9d1f8ef57988"); 
        var roomJId = new Guid("7955e403-91e2-4c7b-b9f4-e9f47ce2b850"); 
        
        var speaker1Id = new Guid("aac7801e-83fc-4f45-89a1-9f867a1efc90");
        var speaker2Id = new Guid("3e499e2f-1db7-4aa9-b3ab-810b5cb7e5b1");
        var speaker3Id = new Guid("f777e354-cb8c-438c-b15e-5d6ad3eb71e6");
        
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
        
        modelBuilder.Entity<Conference>().HasData(
            new Conference
            {
                Id = new Guid("c21926cc-f0bb-4a65-9ac4-9f4e2ed70530"),
                Day = "Jour 1",
                TimeSlot = "9h30 - 10h",
                IdRoom = new Guid("23e25c37-1d79-45f2-b0d5-8f7f4144525c"),
                Title = "Apprentissage Automatique et Transformation Numérique",
                Description = "Une plongée dans les dernières avancées du machine learning et leur application dans les systèmes intelligents. Michel Dupont abordera les enjeux pédagogiques et industriels de l’intelligence artificielle au service de l’innovation.\n\n",
                IdSpeaker = new Guid("aac7801e-83fc-4f45-89a1-9f867a1efc90"),
                Participant = 2
            },
            new Conference
            {
                Id = new Guid("c61f352f-95be-4c41-948a-2cb77a77de1b"),
                Day = "Jour 2",
                TimeSlot = "10h30 - 11h",
                IdRoom = new Guid("16d87d5d-6c25-448c-9bb9-65b0a7c2e729"),
                Title = "Design Éthique et UX : Créer des Interfaces Responsables\n",
                Description = "Découvrez comment allier esthétique, performance et responsabilité dans la conception d’interfaces. Victoria Martin partage son approche du design émotionnel et de l’accessibilité, illustrée par des cas concrets et des pratiques exemplaires du secteur.\n\n",
                IdSpeaker = new Guid("3e499e2f-1db7-4aa9-b3ab-810b5cb7e5b1"),
                Participant = 5
            },
            new Conference
            {
                Id = new Guid("18717e1e-cc3c-4e54-8a89-91c40b27f0a5"),
                Day = "Jour 3",
                TimeSlot = "11h - 12h",
                IdRoom = new Guid("5bcbef3c-9790-4032-84c2-3b0706464b6f"),
                Title = "Métaux du Futur : Science, Innovation et Applications",
                Description = "Albert MetalStein explore les innovations dans le domaine des matériaux métalliques. Il présentera des recherches sur la conductivité, la résistance et les structures quantiques, avec un regard vulgarisé et passionné sur les défis de l’ingénierie moderne.\n\n",
                IdSpeaker = new Guid("f777e354-cb8c-438c-b15e-5d6ad3eb71e6"),
                Participant = 15
            }
        );
        
        modelBuilder.Entity<UserConference>().HasData(
            new UserConference
            {
                Id = new Guid("86a6dfeb-7b9c-4874-9b40-dde63bfc6cf3"),
                IdUser = new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd"),
                IdConference = new Guid("c21926cc-f0bb-4a65-9ac4-9f4e2ed70530")
            },
            new UserConference
            {
                Id = new Guid("fa2c31e3-22f2-4df2-85d1-fcf5b9ae37ae"),
                IdUser = new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd"),
                IdConference = new Guid("c61f352f-95be-4c41-948a-2cb77a77de1b")
            }
        );
        
    }
}