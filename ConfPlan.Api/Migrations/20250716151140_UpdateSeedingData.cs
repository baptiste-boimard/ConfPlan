using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfPlan.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Day", "Description", "IdRoom", "IdSpeaker", "Participant", "TimeSlot", "Title" },
                values: new object[,]
                {
                    { new Guid("18717e1e-cc3c-4e54-8a89-91c40b27f0a5"), "Jour 3", "Albert MetalStein explore les innovations dans le domaine des matériaux métalliques. Il présentera des recherches sur la conductivité, la résistance et les structures quantiques, avec un regard vulgarisé et passionné sur les défis de l’ingénierie moderne.\n\n", new Guid("5bcbef3c-9790-4032-84c2-3b0706464b6f"), new Guid("f777e354-cb8c-438c-b15e-5d6ad3eb71e6"), 15, "11h - 12h", "Métaux du Futur : Science, Innovation et Applications" },
                    { new Guid("c21926cc-f0bb-4a65-9ac4-9f4e2ed70530"), "Jour 1", "Une plongée dans les dernières avancées du machine learning et leur application dans les systèmes intelligents. Michel Dupont abordera les enjeux pédagogiques et industriels de l’intelligence artificielle au service de l’innovation.\n\n", new Guid("23e25c37-1d79-45f2-b0d5-8f7f4144525c"), new Guid("aac7801e-83fc-4f45-89a1-9f867a1efc90"), 2, "9h30 - 10h", "Apprentissage Automatique et Transformation Numérique" },
                    { new Guid("c61f352f-95be-4c41-948a-2cb77a77de1b"), "Jour 2", "Découvrez comment allier esthétique, performance et responsabilité dans la conception d’interfaces. Victoria Martin partage son approche du design émotionnel et de l’accessibilité, illustrée par des cas concrets et des pratiques exemplaires du secteur.\n\n", new Guid("16d87d5d-6c25-448c-9bb9-65b0a7c2e729"), new Guid("3e499e2f-1db7-4aa9-b3ab-810b5cb7e5b1"), 5, "10h30 - 11h", "Design Éthique et UX : Créer des Interfaces Responsables\n" }
                });

            migrationBuilder.InsertData(
                table: "UserConferences",
                columns: new[] { "IdConference", "IdUser", "Id" },
                values: new object[,]
                {
                    { new Guid("c21926cc-f0bb-4a65-9ac4-9f4e2ed70530"), new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd"), new Guid("86a6dfeb-7b9c-4874-9b40-dde63bfc6cf3") },
                    { new Guid("c61f352f-95be-4c41-948a-2cb77a77de1b"), new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd"), new Guid("fa2c31e3-22f2-4df2-85d1-fcf5b9ae37ae") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("18717e1e-cc3c-4e54-8a89-91c40b27f0a5"));

            migrationBuilder.DeleteData(
                table: "UserConferences",
                keyColumns: new[] { "IdConference", "IdUser" },
                keyValues: new object[] { new Guid("c21926cc-f0bb-4a65-9ac4-9f4e2ed70530"), new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd") });

            migrationBuilder.DeleteData(
                table: "UserConferences",
                keyColumns: new[] { "IdConference", "IdUser" },
                keyValues: new object[] { new Guid("c61f352f-95be-4c41-948a-2cb77a77de1b"), new Guid("57df6d2f-4fbd-49f2-89f2-d3b14a91d6cd") });

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("c21926cc-f0bb-4a65-9ac4-9f4e2ed70530"));

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("c61f352f-95be-4c41-948a-2cb77a77de1b"));
        }
    }
}
