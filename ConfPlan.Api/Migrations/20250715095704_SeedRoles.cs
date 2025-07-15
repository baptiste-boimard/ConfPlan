using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
