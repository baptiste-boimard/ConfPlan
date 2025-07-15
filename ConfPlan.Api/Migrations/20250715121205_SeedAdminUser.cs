using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5bbfaa3f-944a-4812-a67e-ff90506d6f7e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a700aba1-add4-4f23-b216-43a92551e92d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab0a16f9-4590-469a-b9de-bb8bdbca9578"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5bbfaa3f-944a-4812-a67e-ff90506d6f7e"), "Admin" },
                    { new Guid("a700aba1-add4-4f23-b216-43a92551e92d"), "Visiteur" },
                    { new Guid("ab0a16f9-4590-469a-b9de-bb8bdbca9578"), "Sponsor" }
                });
        }
    }
}
