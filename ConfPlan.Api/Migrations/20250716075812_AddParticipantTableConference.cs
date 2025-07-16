using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddParticipantTableConference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a4b2bb1-ea16-4cb1-96e0-89e4adff7446"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("502baf9f-1677-41e7-b7ce-6dc03b5b727c"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("06b69cfc-9b90-4117-975b-4e6e0eb7b075"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("19b30ee9-e08e-4a42-8b7b-9aad5d3bc97d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("23abee76-f3e1-471c-804e-e060a1123812"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3548ff19-9a06-4eaa-9ce8-c619599bc0cd"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("37c396c9-5f76-4604-ad59-899adef2ef6c"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("522c6dab-919a-44eb-8c1e-414ce785e430"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("95459bc8-4c61-4a1a-8d9d-147ec723cda3"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c147342e-7353-49bf-b77c-729dce6767c2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d1061fc9-1feb-49d4-a88c-dfbe9e4a283a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e0e53978-44ec-4934-b5bb-9c1fafe0850d"));

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: new Guid("8a5add5b-181e-4011-8ad6-f23680c52423"));

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: new Guid("f6ee5a6f-d806-480d-9b8b-d7017c892a35"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4cd2a163-5375-4b5b-a1b0-ca40560c37f7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dac893ef-d2ea-4c83-84c6-05652083d295"));

            migrationBuilder.AddColumn<int>(
                name: "Participant",
                table: "Conferences",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5dfb69a7-0fb0-4c43-8201-6e64c25a3dc5"), "Sponsor" },
                    { new Guid("8e8b91bb-6ddf-4e04-bc0e-b4413d73226e"), "Admin" },
                    { new Guid("e31a5c92-6c31-4d56-a57d-28079faa20d1"), "Visiteur" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CurrentCapacity", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { new Guid("17484d2c-9828-47ee-8267-163552ea92bc"), 0, 20, "Salle A" },
                    { new Guid("268777fe-d284-4143-8020-ae897e996837"), 0, 50, "Salle G" },
                    { new Guid("338b5faa-016f-490d-a596-39170eb28930"), 0, 5, "Salle E" },
                    { new Guid("59070af0-9014-4aee-9787-eb7bcd645844"), 0, 100, "Salle I" },
                    { new Guid("72c95071-6a14-4cce-ac98-6871cdaa05a7"), 0, 20, "Salle B" },
                    { new Guid("aa505c86-a615-4f0f-a5ae-d072aafa1954"), 0, 50, "Salle H" },
                    { new Guid("aabac7fb-8adb-4ef7-a6c3-cafd16450321"), 0, 5, "Salle F" },
                    { new Guid("c6493823-c56e-4c70-b6c8-f055d6237cce"), 0, 10, "Salle C" },
                    { new Guid("d5b65a6e-e2d2-41bb-89c1-42478a87fd66"), 0, 10, "Salle D" },
                    { new Guid("dd3fe6fe-94bc-4c4c-9eae-81e96669e9b2"), 0, 100, "Salle J" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Bio", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { new Guid("2a5a454b-3b38-4313-9d31-c79e3a8fee90"), "Victoria Martin est une spécialiste de l’UI/UX avec plus de 10 ans d’expérience dans la conception centrée utilisateur.\nElle accompagne des entreprises innovantes dans la création d’interfaces intuitives et engageantes.\nSon approche allie design émotionnel, accessibilité et performance.\nElle intervient régulièrement en conférences pour partager sa vision du design éthique et durable.\nVictoria est également mentor pour de jeunes designers qu’elle forme aux meilleures pratiques du secteur.", "Victoria Martin", "https://images.generated.photos/BAGgXKAepAIfdaVT-GQ2CMaXys3XZ5qdTVIqL1XFN2E/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODE3MTI0LmpwZw.jpg" },
                    { new Guid("7443cc13-31fa-4bef-be9e-fb5c0ea18fce"), "Le professeur Michel Dupont est un expert reconnu en Data Learning, alliant recherche académique et applications industrielles.\nIl enseigne l'intelligence artificielle et le machine learning dans plusieurs établissements de renom.\nSes travaux portent sur l’apprentissage automatique, les réseaux de neurones et les systèmes intelligents.\nIl intervient régulièrement dans des conférences pour partager ses découvertes et pratiques innovantes.\nPassionné par la transmission du savoir, il accompagne aussi des projets en transformation numérique.", "Michel Dupont", "https://images.generated.photos/SRoJei2r0zIOyegFdcuLXagsSfVOY-G_WNLiKFIMy-g/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzMyMzU2LmpwZw.jpg" },
                    { new Guid("c7d0fad3-7c76-4244-aaea-a60e2f1031fb"), "Albert MetalStein est un expert visionnaire en physique des métaux et matériaux avancés.\nSes recherches repoussent les limites de la conductivité, de la résistance et de la transformation des alliages.\nIl est reconnu pour ses travaux sur les propriétés quantiques des structures métalliques.\nConférencier passionné, il vulgarise la science du métal avec précision et énergie.\nAlbert collabore avec des laboratoires et industries à la pointe de l’innovation métallurgique.", "Albert MetalStein", "https://images.generated.photos/IlHIAAkLdeOdb8dHl4uHy7neqz3DgWD4tE7PcqCGzz4/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NTMyNzc5LmpwZw.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "Password" },
                values: new object[] { new Guid("2853a3ff-2298-4458-bdcb-2663a70adcd2"), "admin@confplan.dev", new Guid("8e8b91bb-6ddf-4e04-bc0e-b4413d73226e"), "$2a$12$ytsbB3JQWKgtrDjAFVJm3eASfxMqBqE8JlYDXBzkPbwt28oFP9unq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5dfb69a7-0fb0-4c43-8201-6e64c25a3dc5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e31a5c92-6c31-4d56-a57d-28079faa20d1"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("17484d2c-9828-47ee-8267-163552ea92bc"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("268777fe-d284-4143-8020-ae897e996837"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("338b5faa-016f-490d-a596-39170eb28930"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("59070af0-9014-4aee-9787-eb7bcd645844"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("72c95071-6a14-4cce-ac98-6871cdaa05a7"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("aa505c86-a615-4f0f-a5ae-d072aafa1954"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("aabac7fb-8adb-4ef7-a6c3-cafd16450321"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c6493823-c56e-4c70-b6c8-f055d6237cce"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d5b65a6e-e2d2-41bb-89c1-42478a87fd66"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("dd3fe6fe-94bc-4c4c-9eae-81e96669e9b2"));

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: new Guid("2a5a454b-3b38-4313-9d31-c79e3a8fee90"));

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: new Guid("7443cc13-31fa-4bef-be9e-fb5c0ea18fce"));

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: new Guid("c7d0fad3-7c76-4244-aaea-a60e2f1031fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2853a3ff-2298-4458-bdcb-2663a70adcd2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8e8b91bb-6ddf-4e04-bc0e-b4413d73226e"));

            migrationBuilder.DropColumn(
                name: "Participant",
                table: "Conferences");

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
        }
    }
}
