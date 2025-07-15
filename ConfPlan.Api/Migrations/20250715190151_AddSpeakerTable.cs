using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSpeakerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75115e60-39ed-43de-ab04-b0de37753703"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ed3f8988-a5cf-4e5e-925e-238dc90ec0eb"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("02ad0587-9a12-40f9-950e-cfbf9fca42ef"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3953e1fd-af4d-4b97-8ab3-f64fea2eae04"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("51211ce8-67e9-496b-9add-2e4875c7962a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("60ca597c-72d0-4454-bc69-1df6c1e0242a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("70e5043b-3ed4-4fd5-8473-86bd407170c0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7677d878-0bb4-4606-a641-80b29877ff95"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7bf76c10-5763-4935-9607-52c67982579a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("96625fba-b7cf-4a3f-bf6e-07aa490370c4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9ac9f4c2-893a-45e6-84a1-80249ed16d9a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d3ef5b18-5934-4567-88b9-2407537025a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f89c3a97-e6b1-4f51-a674-c3cf1862ad7c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bcc28637-ab86-4d36-a872-4cefebbc9691"));

            migrationBuilder.DropColumn(
                name: "SpeakerBio",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "SpeakerName",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "SpeakerPhotoUrl",
                table: "Conferences");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSpeaker",
                table: "Conferences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5d98fc72-464d-42fd-9652-0c56aecc4bf9"), "Sponsor" },
                    { new Guid("b63e1ea1-ef8d-4be1-8115-ec5f169bc564"), "Visiteur" },
                    { new Guid("ef3ec6e3-4f8f-4cb9-a07b-084d84a98b7d"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CurrentCapacity", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { new Guid("0a8fa030-8303-4e44-8ac6-638b91562d2e"), 0, 100, "Salle I" },
                    { new Guid("0e96e35e-ecbc-4d0a-9a9f-aa98f0c8b1d0"), 0, 100, "Salle J" },
                    { new Guid("18771ff6-267d-4226-bb47-ad63d69153e4"), 0, 10, "Salle D" },
                    { new Guid("1a711493-a769-4fe4-a953-ce1bc38ae73e"), 0, 20, "Salle B" },
                    { new Guid("30a0f0d5-ebab-4847-8add-e49ec415627e"), 0, 20, "Salle A" },
                    { new Guid("35964b1d-05b9-4b96-ae3a-1e06d4b13faa"), 0, 10, "Salle C" },
                    { new Guid("503ade23-dcef-4a22-b1b7-abce20a69ae5"), 0, 5, "Salle E" },
                    { new Guid("f003f018-d373-4b00-9b57-774142f23def"), 0, 50, "Salle G" },
                    { new Guid("f6f7e235-95e9-420b-81bc-9eafe69e7089"), 0, 50, "Salle H" },
                    { new Guid("f8d55469-8bfa-4a9f-b6f5-03067c22633b"), 0, 5, "Salle F" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("d75f3945-c050-460b-8c3c-2c82ee40ae6f"), "admin@confplan.dev", new Guid("ef3ec6e3-4f8f-4cb9-a07b-084d84a98b7d"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_IdSpeaker",
                table: "Conferences",
                column: "IdSpeaker",
                unique: true);

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
                name: "FK_Conferences_Speakers_IdSpeaker",
                table: "Conferences");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Conferences_IdSpeaker",
                table: "Conferences");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5d98fc72-464d-42fd-9652-0c56aecc4bf9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b63e1ea1-ef8d-4be1-8115-ec5f169bc564"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0a8fa030-8303-4e44-8ac6-638b91562d2e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0e96e35e-ecbc-4d0a-9a9f-aa98f0c8b1d0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("18771ff6-267d-4226-bb47-ad63d69153e4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1a711493-a769-4fe4-a953-ce1bc38ae73e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("30a0f0d5-ebab-4847-8add-e49ec415627e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("35964b1d-05b9-4b96-ae3a-1e06d4b13faa"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("503ade23-dcef-4a22-b1b7-abce20a69ae5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f003f018-d373-4b00-9b57-774142f23def"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f6f7e235-95e9-420b-81bc-9eafe69e7089"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f8d55469-8bfa-4a9f-b6f5-03067c22633b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d75f3945-c050-460b-8c3c-2c82ee40ae6f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef3ec6e3-4f8f-4cb9-a07b-084d84a98b7d"));

            migrationBuilder.DropColumn(
                name: "IdSpeaker",
                table: "Conferences");

            migrationBuilder.AddColumn<string>(
                name: "SpeakerBio",
                table: "Conferences",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpeakerName",
                table: "Conferences",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpeakerPhotoUrl",
                table: "Conferences",
                type: "text",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
