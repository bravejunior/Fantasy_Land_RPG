using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class dbFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Capabilities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameColumn(
                name: "AbilityId",
                table: "ProfessionProgressions",
                newName: "SkillPoints");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ProfessionId",
                table: "Skills",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Professions_ProfessionId",
                table: "Skills",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Professions_ProfessionId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ProfessionId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "SkillPoints",
                table: "ProfessionProgressions",
                newName: "AbilityId");

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    ProfessionProgressionId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_ProfessionProgressions_ProfessionProgressionId",
                        column: x => x.ProfessionProgressionId,
                        principalTable: "ProfessionProgressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Abilities_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Capabilities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The ability to influence and convince others through effective communication and reasoning, persuading them to see things from your perspective or take a desired course of action.", "Persuasion" },
                    { 2, "The skill to engage in discussions and reach mutually beneficial agreements, finding compromises and resolving conflicts by considering the needs and interests of all parties involved.", "Negotiation" },
                    { 3, "The talent for gathering information, examining evidence, and uncovering the truth. It involves a meticulous and systematic approach to explore and solve mysteries, crimes, or complex situations.", "Investigation" },
                    { 4, "The proficiency in moving silently and remaining undetected, whether it's sneaking past guards, hiding in shadows, or executing covert operations without raising suspicion or alerting others.", "Stealth" },
                    { 5, "The breadth and depth of understanding and information about various subjects, acquired through study, learning, and experience. It encompasses expertise in specific fields, historical facts, lore, and practical know-how.", "Knowledge" },
                    { 6, "The keenness of senses and observation, allowing one to notice and interpret subtle details, patterns, and cues in the environment. It involves being aware of one's surroundings and detecting hidden or obscured information.", "Perception" },
                    { 7, "The natural charm, magnetism, and ability to inspire and captivate others through personal presence and engaging communication. It can create a positive impression, build rapport, and win people's trust and admiration.", "Charisma" },
                    { 8, "The capacity to understand and share the emotions, perspectives, and experiences of others. It involves being sensitive to others' feelings, showing compassion, and being able to connect with and relate to their situations.", "Empathy" },
                    { 9, "The stamina, physical and mental resilience, and ability to withstand and persevere through challenging or demanding situations, such as physical exertion, prolonged stress, or difficult circumstances.", "Endurance" },
                    { 10, "The flexibility and ability to adjust and thrive in different or changing environments, circumstances, or roles. It includes being open to new ideas, being resourceful, and effectively responding to unexpected challenges.", "Adaptability" },
                    { 11, "The skill to develop long-term plans and approaches to achieve specific goals. It involves analyzing situations, anticipating outcomes, and making calculated decisions to gain advantages and overcome obstacles.", "Strategy" },
                    { 12, "The capability to guide, inspire, and influence others to work towards a common objective. It includes setting a vision, making sound decisions, delegating tasks, and fostering collaboration and growth within a team or organization.", "Leadership" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_ProfessionId",
                table: "Abilities",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_ProfessionProgressionId",
                table: "Abilities",
                column: "ProfessionProgressionId",
                unique: true,
                filter: "[ProfessionProgressionId] IS NOT NULL");
        }
    }
}
