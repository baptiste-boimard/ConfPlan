using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IdRole = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<string>(type: "text", nullable: false),
                    TimeSlot = table.Column<string>(type: "text", nullable: false),
                    IdRoom = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IdSpeaker = table.Column<Guid>(type: "uuid", nullable: false),
                    Participant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxCapacity = table.Column<int>(type: "integer", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "integer", nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserConferences",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uuid", nullable: false),
                    IdConference = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConferences", x => new { x.IdUser, x.IdConference });
                    table.ForeignKey(
                        name: "FK_UserConferences_Conferences_IdConference",
                        column: x => x.IdConference,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserConferences_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("8a738c4e-9c30-48d2-9817-f59a657e529c"), "Visiteur" },
                    { new Guid("a3fef80b-2b2e-46d1-a88e-123d0d7a7615"), "Sponsor" },
                    { new Guid("d5ab69c2-4b14-4a15-8a90-1b3a86eb8aa2"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ConferenceId", "CurrentCapacity", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { new Guid("0f29a8cb-4931-4b60-9473-fd2a3932e2d3"), null, 0, 10, "Salle D" },
                    { new Guid("16d87d5d-6c25-448c-9bb9-65b0a7c2e729"), null, 0, 20, "Salle B" },
                    { new Guid("23e25c37-1d79-45f2-b0d5-8f7f4144525c"), null, 0, 20, "Salle A" },
                    { new Guid("2aa6be59-5803-4de3-b7f3-9d1f8ef57988"), null, 0, 100, "Salle I" },
                    { new Guid("5bcbef3c-9790-4032-84c2-3b0706464b6f"), null, 0, 10, "Salle C" },
                    { new Guid("7955e403-91e2-4c7b-b9f4-e9f47ce2b850"), null, 0, 100, "Salle J" },
                    { new Guid("7dc3d927-2f26-4c39-bdd2-4b6e17b7d0ac"), null, 0, 5, "Salle E" },
                    { new Guid("902beee3-83f5-48c6-8b5b-2214e03bdb20"), null, 0, 50, "Salle G" },
                    { new Guid("d4fd6f46-7788-4f78-a79a-2f0a5f8c2e7e"), null, 0, 5, "Salle F" },
                    { new Guid("f203c2a4-69b7-43ee-8133-547b1928a99a"), null, 0, 50, "Salle H" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Bio", "ConferenceId", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { new Guid("3e499e2f-1db7-4aa9-b3ab-810b5cb7e5b1"), "Victoria Martin est une spécialiste de l’UI/UX avec plus de 10 ans d’expérience dans la conception centrée utilisateur.\nElle accompagne des entreprises innovantes dans la création d’interfaces intuitives et engageantes.\nSon approche allie design émotionnel, accessibilité et performance.\nElle intervient régulièrement en conférences pour partager sa vision du design éthique et durable.\nVictoria est également mentor pour de jeunes designers qu’elle forme aux meilleures pratiques du secteur.", null, "Victoria Martin", "https://images.generated.photos/BAGgXKAepAIfdaVT-GQ2CMaXys3XZ5qdTVIqL1XFN2E/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODE3MTI0LmpwZw.jpg" },
                    { new Guid("aac7801e-83fc-4f45-89a1-9f867a1efc90"), "Le professeur Michel Dupont est un expert reconnu en Data Learning, alliant recherche académique et applications industrielles.\nIl enseigne l'intelligence artificielle et le machine learning dans plusieurs établissements de renom.\nSes travaux portent sur l’apprentissage automatique, les réseaux de neurones et les systèmes intelligents.\nIl intervient régulièrement dans des conférences pour partager ses découvertes et pratiques innovantes.\nPassionné par la transmission du savoir, il accompagne aussi des projets en transformation numérique.", null, "Michel Dupont", "https://images.generated.photos/SRoJei2r0zIOyegFdcuLXagsSfVOY-G_WNLiKFIMy-g/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzMyMzU2LmpwZw.jpg" },
                    { new Guid("f777e354-cb8c-438c-b15e-5d6ad3eb71e6"), "Albert MetalStein est un expert visionnaire en physique des métaux et matériaux avancés.\nSes recherches repoussent les limites de la conductivité, de la résistance et de la transformation des alliages.\nIl est reconnu pour ses travaux sur les propriétés quantiques des structures métalliques.\nConférencier passionné, il vulgarise la science du métal avec précision et énergie.\nAlbert collabore avec des laboratoires et industries à la pointe de l’innovation métallurgique.", null, "Albert MetalStein", "https://images.generated.photos/IlHIAAkLdeOdb8dHl4uHy7neqz3DgWD4tE7PcqCGzz4/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NTMyNzc5LmpwZw.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd"), "admin@confplan.dev", new Guid("d5ab69c2-4b14-4a15-8a90-1b3a86eb8aa2"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_IdRoom",
                table: "Conferences",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_IdSpeaker",
                table: "Conferences",
                column: "IdSpeaker");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ConferenceId",
                table: "Rooms",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ConferenceId",
                table: "Speakers",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConferences_IdConference",
                table: "UserConferences",
                column: "IdConference");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_Rooms_IdRoom",
                table: "Conferences",
                column: "IdRoom",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_Speakers_IdSpeaker",
                table: "Conferences",
                column: "IdSpeaker",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_Rooms_IdRoom",
                table: "Conferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_Speakers_IdSpeaker",
                table: "Conferences");

            migrationBuilder.DropTable(
                name: "UserConferences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}
