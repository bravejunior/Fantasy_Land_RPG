using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class attributedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Insight represents a character's ability to delve into complex subjects and gain deep understanding through critical thinking, and analytical skills.", "Insight" },
                    { 2, "Resilience represents a character's unwavering determination and unyielding spirit in the face of the realm's grim fate.", "Resilience" },
                    { 3, "Intrigue represents a character's adeptness at navigating the complex political landscape of Distrea.", "Intrigue" },
                    { 4, "Intuition represents a character's instinct, gut feeling, and the ability to read between the lines.", "Intuition" },
                    { 5, "Presence represents a character's personal magnetism, natural charisma, and ability to inspire and influence others through their words and actions.", "Presence" },
                    { 6, "Observation represents a character's keen attention to detail, heightened awareness, and ability to perceive subtle clues and patterns in their surroundings.", "Observation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
