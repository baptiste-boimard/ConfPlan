using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    { new Guid("46c7b826-77cb-4703-b9bd-0bcb02c009f0"), "Admin" },
                    { new Guid("8ed44415-8ce7-4c1f-8a62-46733981076f"), "Sponsor" },
                    { new Guid("f78bf1cd-eecb-4052-acfd-54321b9e910d"), "Visiteur" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ConferenceId", "CurrentCapacity", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { new Guid("2c06bfb2-bce5-4e65-8773-f71e0c98b9b7"), null, 0, 5, "Salle F" },
                    { new Guid("4f3990c3-b645-4bf1-b8e1-b52d43d84fe8"), null, 0, 20, "Salle B" },
                    { new Guid("5738529c-4a0a-4377-8ea4-9b56d1f7dd9c"), null, 0, 100, "Salle J" },
                    { new Guid("6db3c227-dc34-45be-b41f-9cc8580c06f2"), null, 0, 5, "Salle E" },
                    { new Guid("7de57b4a-48ed-4372-a5b1-8e821e08f0d2"), null, 0, 50, "Salle H" },
                    { new Guid("883b96b3-7068-4d96-a961-b3a66f8fe684"), null, 0, 20, "Salle A" },
                    { new Guid("98c6bf3e-af97-4468-be47-ee62b947ff71"), null, 0, 10, "Salle C" },
                    { new Guid("d493d774-4736-42f0-a200-ef7192161732"), null, 0, 50, "Salle G" },
                    { new Guid("db45d60d-3156-4532-903e-1a1d86e6a723"), null, 0, 100, "Salle I" },
                    { new Guid("e1fc04ea-72e4-4dfc-8abe-a26701405ec2"), null, 0, 10, "Salle D" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Bio", "ConferenceId", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { new Guid("acadf356-4043-42dc-a17d-67fc151b84dd"), "Albert MetalStein est un expert visionnaire en physique des métaux et matériaux avancés.\nSes recherches repoussent les limites de la conductivité, de la résistance et de la transformation des alliages.\nIl est reconnu pour ses travaux sur les propriétés quantiques des structures métalliques.\nConférencier passionné, il vulgarise la science du métal avec précision et énergie.\nAlbert collabore avec des laboratoires et industries à la pointe de l’innovation métallurgique.", null, "Albert MetalStein", "https://images.generated.photos/IlHIAAkLdeOdb8dHl4uHy7neqz3DgWD4tE7PcqCGzz4/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NTMyNzc5LmpwZw.jpg" },
                    { new Guid("ad04d6af-c784-4aa7-b12e-d430d3e4e812"), "Victoria Martin est une spécialiste de l’UI/UX avec plus de 10 ans d’expérience dans la conception centrée utilisateur.\nElle accompagne des entreprises innovantes dans la création d’interfaces intuitives et engageantes.\nSon approche allie design émotionnel, accessibilité et performance.\nElle intervient régulièrement en conférences pour partager sa vision du design éthique et durable.\nVictoria est également mentor pour de jeunes designers qu’elle forme aux meilleures pratiques du secteur.", null, "Victoria Martin", "https://images.generated.photos/BAGgXKAepAIfdaVT-GQ2CMaXys3XZ5qdTVIqL1XFN2E/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODE3MTI0LmpwZw.jpg" },
                    { new Guid("bbecb148-8c52-49cb-b5e0-b839c9d34fa3"), "Le professeur Michel Dupont est un expert reconnu en Data Learning, alliant recherche académique et applications industrielles.\nIl enseigne l'intelligence artificielle et le machine learning dans plusieurs établissements de renom.\nSes travaux portent sur l’apprentissage automatique, les réseaux de neurones et les systèmes intelligents.\nIl intervient régulièrement dans des conférences pour partager ses découvertes et pratiques innovantes.\nPassionné par la transmission du savoir, il accompagne aussi des projets en transformation numérique.", null, "Michel Dupont", "https://images.generated.photos/SRoJei2r0zIOyegFdcuLXagsSfVOY-G_WNLiKFIMy-g/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzMyMzU2LmpwZw.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("731e2c1f-a83e-4faf-8439-45079e856617"), "admin@confplan.dev", new Guid("46c7b826-77cb-4703-b9bd-0bcb02c009f0"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });

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
