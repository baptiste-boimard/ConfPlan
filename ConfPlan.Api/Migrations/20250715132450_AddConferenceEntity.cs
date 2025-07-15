using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddConferenceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1eb63454-e0ba-498c-8f96-7c5ac5dab4d7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("755cc5ae-cab8-49ba-ad23-043514612563"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52c2a32b-2cf3-40eb-a9af-a95de279be6a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ca9bc5bf-00b0-4ce5-8957-942ddabc880d"));

            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<string>(type: "text", nullable: false),
                    TimeSlot = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SpeakerName = table.Column<string>(type: "text", nullable: false),
                    SpeakerBio = table.Column<string>(type: "text", nullable: false),
                    SpeakerPhotoUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("7cd5abea-cfd0-4814-804f-bd8be9895864"), "Visiteur" },
                    { new Guid("a8fc4bf0-99a5-45f3-89f8-09e6e74fbd97"), "Admin" },
                    { new Guid("c6f2995f-be6b-4d50-a79f-94abc176ac26"), "Sponsor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("7604f4fd-504e-4174-b85c-b6a7c542d1ce"), "admin@confplan.dev", new Guid("a8fc4bf0-99a5-45f3-89f8-09e6e74fbd97"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conference");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7cd5abea-cfd0-4814-804f-bd8be9895864"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c6f2995f-be6b-4d50-a79f-94abc176ac26"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7604f4fd-504e-4174-b85c-b6a7c542d1ce"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a8fc4bf0-99a5-45f3-89f8-09e6e74fbd97"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1eb63454-e0ba-498c-8f96-7c5ac5dab4d7"), "Sponsor" },
                    { new Guid("755cc5ae-cab8-49ba-ad23-043514612563"), "Visiteur" },
                    { new Guid("ca9bc5bf-00b0-4ce5-8957-942ddabc880d"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("52c2a32b-2cf3-40eb-a9af-a95de279be6a"), "bouketin@confplan.dev", new Guid("ca9bc5bf-00b0-4ce5-8957-942ddabc880d"), "$2a$12$RKz5UHTyY7XzGrwz2OdxO.WLBQnYqG0/nXci/3qFJxuulx0WwX3X6" });
        }
    }
}
