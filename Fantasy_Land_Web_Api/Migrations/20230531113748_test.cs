using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionProgressions_Professions_ProfessionId",
                table: "ProfessionProgressions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionProgressions_Professions_ProfessionId1",
                table: "ProfessionProgressions");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionProgressions_ProfessionId1",
                table: "ProfessionProgressions");

            migrationBuilder.DropColumn(
                name: "ProfessionId1",
                table: "ProfessionProgressions");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionProgressions_Professions_ProfessionId",
                table: "ProfessionProgressions",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionProgressions_Professions_ProfessionId",
                table: "ProfessionProgressions");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId1",
                table: "ProfessionProgressions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionProgressions_ProfessionId1",
                table: "ProfessionProgressions",
                column: "ProfessionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionProgressions_Professions_ProfessionId",
                table: "ProfessionProgressions",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionProgressions_Professions_ProfessionId1",
                table: "ProfessionProgressions",
                column: "ProfessionId1",
                principalTable: "Professions",
                principalColumn: "Id");
        }
    }
}
