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
                    SpeakerName = table.Column<string>(type: "text", nullable: false),
                    SpeakerBio = table.Column<string>(type: "text", nullable: false),
                    SpeakerPhotoUrl = table.Column<string>(type: "text", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("75115e60-39ed-43de-ab04-b0de37753703"), "Visiteur" },
                    { new Guid("bcc28637-ab86-4d36-a872-4cefebbc9691"), "Admin" },
                    { new Guid("ed3f8988-a5cf-4e5e-925e-238dc90ec0eb"), "Sponsor" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CurrentCapacity", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { new Guid("02ad0587-9a12-40f9-950e-cfbf9fca42ef"), 0, 20, "Salle A" },
                    { new Guid("3953e1fd-af4d-4b97-8ab3-f64fea2eae04"), 0, 10, "Salle D" },
                    { new Guid("51211ce8-67e9-496b-9add-2e4875c7962a"), 0, 50, "Salle H" },
                    { new Guid("60ca597c-72d0-4454-bc69-1df6c1e0242a"), 0, 10, "Salle C" },
                    { new Guid("70e5043b-3ed4-4fd5-8473-86bd407170c0"), 0, 100, "Salle J" },
                    { new Guid("7677d878-0bb4-4606-a641-80b29877ff95"), 0, 20, "Salle B" },
                    { new Guid("7bf76c10-5763-4935-9607-52c67982579a"), 0, 5, "Salle E" },
                    { new Guid("96625fba-b7cf-4a3f-bf6e-07aa490370c4"), 0, 50, "Salle G" },
                    { new Guid("9ac9f4c2-893a-45e6-84a1-80249ed16d9a"), 0, 5, "Salle F" },
                    { new Guid("d3ef5b18-5934-4567-88b9-2407537025a1"), 0, 100, "Salle I" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("f89c3a97-e6b1-4f51-a674-c3cf1862ad7c"), "admin@confplan.dev", new Guid("bcc28637-ab86-4d36-a872-4cefebbc9691"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_IdRoom",
                table: "Conferences",
                column: "IdRoom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
