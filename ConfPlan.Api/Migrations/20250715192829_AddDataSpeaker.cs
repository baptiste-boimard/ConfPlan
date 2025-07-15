using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSpeaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("76ada4c9-9305-41f0-ba88-0e6e097a0e08"), "Sponsor" },
                    { new Guid("8fbd85cc-6024-40a7-b938-1cc594461406"), "Admin" },
                    { new Guid("f9b32cdd-cf9a-47cd-a008-20cadd58cc6e"), "Visiteur" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CurrentCapacity", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { new Guid("116f273e-e810-4c4d-ad7f-0a160433d3c9"), 0, 20, "Salle A" },
                    { new Guid("145fc8e0-7e39-4a33-9876-9afe05ca0b50"), 0, 50, "Salle H" },
                    { new Guid("18b2337f-32eb-4529-99c8-2769ecdced97"), 0, 5, "Salle F" },
                    { new Guid("2dc526f4-32da-4fd3-85e3-3327764d255c"), 0, 10, "Salle D" },
                    { new Guid("3c9544f9-d913-404b-81e6-882bc48539b6"), 0, 100, "Salle J" },
                    { new Guid("69db7141-1674-4f95-b83a-b7f1938012ff"), 0, 50, "Salle G" },
                    { new Guid("b89a42b7-ac2d-4fae-a609-b6732b0dfa79"), 0, 100, "Salle I" },
                    { new Guid("d1a4f623-23a0-4d33-afb5-c17922d9b2da"), 0, 10, "Salle C" },
                    { new Guid("d47abafb-ae96-42a0-a669-4e91dc1fa6d6"), 0, 5, "Salle E" },
                    { new Guid("fcc46870-f79b-4132-b311-629ec2923870"), 0, 20, "Salle B" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Bio", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { new Guid("93d9843c-beca-40fb-8537-381df1705b7e"), "Le professeur Michel Dupont est un expert reconnu en Data Learning, alliant recherche académique et applications industrielles.\nIl enseigne l'intelligence artificielle et le machine learning dans plusieurs établissements de renom.\nSes travaux portent sur l’apprentissage automatique, les réseaux de neurones et les systèmes intelligents.\nIl intervient régulièrement dans des conférences pour partager ses découvertes et pratiques innovantes.\nPassionné par la transmission du savoir, il accompagne aussi des projets en transformation numérique.", "Michel Dupont", "https://images.generated.photos/SRoJei2r0zIOyegFdcuLXagsSfVOY-G_WNLiKFIMy-g/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzMyMzU2LmpwZw.jpg" },
                    { new Guid("e8ba26dd-bf53-44c1-b97a-d21889b582fa"), "Victoria Martin est une spécialiste de l’UI/UX avec plus de 10 ans d’expérience dans la conception centrée utilisateur.\nElle accompagne des entreprises innovantes dans la création d’interfaces intuitives et engageantes.\nSon approche allie design émotionnel, accessibilité et performance.\nElle intervient régulièrement en conférences pour partager sa vision du design éthique et durable.\nVictoria est également mentor pour de jeunes designers qu’elle forme aux meilleures pratiques du secteur.", "Victoria Martin", "https://images.generated.photos/BAGgXKAepAIfdaVT-GQ2CMaXys3XZ5qdTVIqL1XFN2E/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODE3MTI0LmpwZw.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("74d143dc-0f56-41af-b50f-a4416c016d8b"), "admin@confplan.dev", new Guid("8fbd85cc-6024-40a7-b938-1cc594461406"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("76ada4c9-9305-41f0-ba88-0e6e097a0e08"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f9b32cdd-cf9a-47cd-a008-20cadd58cc6e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("116f273e-e810-4c4d-ad7f-0a160433d3c9"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("145fc8e0-7e39-4a33-9876-9afe05ca0b50"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("18b2337f-32eb-4529-99c8-2769ecdced97"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("2dc526f4-32da-4fd3-85e3-3327764d255c"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3c9544f9-d913-404b-81e6-882bc48539b6"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("69db7141-1674-4f95-b83a-b7f1938012ff"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b89a42b7-ac2d-4fae-a609-b6732b0dfa79"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d1a4f623-23a0-4d33-afb5-c17922d9b2da"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d47abafb-ae96-42a0-a669-4e91dc1fa6d6"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fcc46870-f79b-4132-b311-629ec2923870"));

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: new Guid("93d9843c-beca-40fb-8537-381df1705b7e"));

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: new Guid("e8ba26dd-bf53-44c1-b97a-d21889b582fa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("74d143dc-0f56-41af-b50f-a4416c016d8b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8fbd85cc-6024-40a7-b938-1cc594461406"));

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
        }
    }
}
