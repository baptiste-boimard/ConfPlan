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
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxCapacity = table.Column<int>(type: "integer", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
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
                    IdSpeaker = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conferences_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conferences_Speakers_IdSpeaker",
                        column: x => x.IdSpeaker,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { new Guid("4a4b2bb1-ea16-4cb1-96e0-89e4adff7446"), "Sponsor" },
                    { new Guid("502baf9f-1677-41e7-b7ce-6dc03b5b727c"), "Visiteur" },
                    { new Guid("dac893ef-d2ea-4c83-84c6-05652083d295"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CurrentCapacity", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { new Guid("06b69cfc-9b90-4117-975b-4e6e0eb7b075"), 0, 10, "Salle D" },
                    { new Guid("19b30ee9-e08e-4a42-8b7b-9aad5d3bc97d"), 0, 50, "Salle G" },
                    { new Guid("23abee76-f3e1-471c-804e-e060a1123812"), 0, 20, "Salle B" },
                    { new Guid("3548ff19-9a06-4eaa-9ce8-c619599bc0cd"), 0, 100, "Salle J" },
                    { new Guid("37c396c9-5f76-4604-ad59-899adef2ef6c"), 0, 5, "Salle E" },
                    { new Guid("522c6dab-919a-44eb-8c1e-414ce785e430"), 0, 50, "Salle H" },
                    { new Guid("95459bc8-4c61-4a1a-8d9d-147ec723cda3"), 0, 5, "Salle F" },
                    { new Guid("c147342e-7353-49bf-b77c-729dce6767c2"), 0, 100, "Salle I" },
                    { new Guid("d1061fc9-1feb-49d4-a88c-dfbe9e4a283a"), 0, 20, "Salle A" },
                    { new Guid("e0e53978-44ec-4934-b5bb-9c1fafe0850d"), 0, 10, "Salle C" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Bio", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { new Guid("8a5add5b-181e-4011-8ad6-f23680c52423"), "Le professeur Michel Dupont est un expert reconnu en Data Learning, alliant recherche académique et applications industrielles.\nIl enseigne l'intelligence artificielle et le machine learning dans plusieurs établissements de renom.\nSes travaux portent sur l’apprentissage automatique, les réseaux de neurones et les systèmes intelligents.\nIl intervient régulièrement dans des conférences pour partager ses découvertes et pratiques innovantes.\nPassionné par la transmission du savoir, il accompagne aussi des projets en transformation numérique.", "Michel Dupont", "https://images.generated.photos/SRoJei2r0zIOyegFdcuLXagsSfVOY-G_WNLiKFIMy-g/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzMyMzU2LmpwZw.jpg" },
                    { new Guid("f6ee5a6f-d806-480d-9b8b-d7017c892a35"), "Victoria Martin est une spécialiste de l’UI/UX avec plus de 10 ans d’expérience dans la conception centrée utilisateur.\nElle accompagne des entreprises innovantes dans la création d’interfaces intuitives et engageantes.\nSon approche allie design émotionnel, accessibilité et performance.\nElle intervient régulièrement en conférences pour partager sa vision du design éthique et durable.\nVictoria est également mentor pour de jeunes designers qu’elle forme aux meilleures pratiques du secteur.", "Victoria Martin", "https://images.generated.photos/BAGgXKAepAIfdaVT-GQ2CMaXys3XZ5qdTVIqL1XFN2E/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODE3MTI0LmpwZw.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("4cd2a163-5375-4b5b-a1b0-ca40560c37f7"), "admin@confplan.dev", new Guid("dac893ef-d2ea-4c83-84c6-05652083d295"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_IdRoom",
                table: "Conferences",
                column: "IdRoom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_IdSpeaker",
                table: "Conferences",
                column: "IdSpeaker",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserConferences_IdConference",
                table: "UserConferences",
                column: "IdConference");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserConferences");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
