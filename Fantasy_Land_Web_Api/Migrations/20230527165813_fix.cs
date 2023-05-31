using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Portrait_PortraitId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Npc_Portrait_PortraitId",
                table: "Npc");

            migrationBuilder.DropForeignKey(
                name: "FK_Portrait_CharacterClasses_CharacterClassId",
                table: "Portrait");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portrait",
                table: "Portrait");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Npc",
                table: "Npc");

            migrationBuilder.RenameTable(
                name: "Portrait",
                newName: "Portraits");

            migrationBuilder.RenameTable(
                name: "Npc",
                newName: "Npcs");

            migrationBuilder.RenameIndex(
                name: "IX_Portrait_CharacterClassId",
                table: "Portraits",
                newName: "IX_Portraits_CharacterClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Npc_PortraitId",
                table: "Npcs",
                newName: "IX_Npcs_PortraitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portraits",
                table: "Portraits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Npcs",
                table: "Npcs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Portraits_PortraitId",
                table: "Characters",
                column: "PortraitId",
                principalTable: "Portraits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Npcs_Portraits_PortraitId",
                table: "Npcs",
                column: "PortraitId",
                principalTable: "Portraits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portraits_CharacterClasses_CharacterClassId",
                table: "Portraits",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Portraits_PortraitId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Npcs_Portraits_PortraitId",
                table: "Npcs");

            migrationBuilder.DropForeignKey(
                name: "FK_Portraits_CharacterClasses_CharacterClassId",
                table: "Portraits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portraits",
                table: "Portraits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Npcs",
                table: "Npcs");

            migrationBuilder.RenameTable(
                name: "Portraits",
                newName: "Portrait");

            migrationBuilder.RenameTable(
                name: "Npcs",
                newName: "Npc");

            migrationBuilder.RenameIndex(
                name: "IX_Portraits_CharacterClassId",
                table: "Portrait",
                newName: "IX_Portrait_CharacterClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Npcs_PortraitId",
                table: "Npc",
                newName: "IX_Npc_PortraitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portrait",
                table: "Portrait",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Npc",
                table: "Npc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Portrait_PortraitId",
                table: "Characters",
                column: "PortraitId",
                principalTable: "Portrait",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Npc_Portrait_PortraitId",
                table: "Npc",
                column: "PortraitId",
                principalTable: "Portrait",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portrait_CharacterClasses_CharacterClassId",
                table: "Portrait",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");
        }
    }
}
