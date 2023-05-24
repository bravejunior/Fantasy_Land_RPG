using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAbstractBaseclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "CharismaBonus", "Description", "Discriminator", "Name" },
                values: new object[] { 1, 1, "Default knight", "Knight", "Knight" });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "CharismaBonus", "DamagePenalty", "DefenceBonus", "Description", "Discriminator", "Name" },
                values: new object[] { 2, 0, -1, 1, "Defensive knight", "Guardian", "Guardian" });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "CharismaBonus", "DamageBonus", "DefencePenalty", "Description", "Discriminator", "Name" },
                values: new object[] { 3, 0, 1, -1, "Offensive knight", "Berserker", "Berserker" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
