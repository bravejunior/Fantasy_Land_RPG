using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class professions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Diplomats possess a deep understanding of cultural nuances and a gift for effective communication. Their gameplay revolves around building bridges between factions, resolving disputes through diplomatic dialogue, and using their persuasive abilities to forge alliances and maintain peace. With a focus on tactful negotiations, cultural diplomacy, and effective mediation, diplomats excel at defusing tensions, promoting harmony, and ensuring the realm's stability.", "Diplomat" },
                    { 2, "Inquisitors are relentless seekers of truth and justice, driven by a strong sense of righteousness. They possess sharp deductive skills and an unwavering determination to uncover the facts. Inquisitors specialize in uncovering hidden secrets, solving intricate puzzles, and bringing criminals to justice. With a focus on investigative techniques, logical reasoning, and keen observation, inquisitors excel at collecting evidence, interrogating suspects, and piecing together the truth behind mysterious events.", "Inquisitor" },
                    { 3, "Historians are scholars and historians who delve into the rich tapestry of the realm's history and legends. They have a deep reverence for ancient knowledge and a thirst for uncovering forgotten truths. Historians specialize in researching ancient texts, deciphering cryptic symbols, and unlocking the secrets of the past. With a focus on historical research, mythological understanding, and archival exploration, historians excel at unearthing lost lore, decoding ancient prophecies, and unraveling the enigmatic mysteries of the realm's past.", "Historian" },
                    { 4, "Orators are charismatic individuals gifted with the power of persuasion and the ability to captivate audiences with their words. They possess a natural eloquence and a magnetic presence that draws others to them. Orators specialize in delivering powerful speeches, swaying public opinion, and influencing important decision-makers. With a focus on public speaking, rhetorical finesse, and emotional intelligence, orators excel at inspiring others, rallying troops, and making impactful arguments that shape the realm's narrative.", "Orator" },
                    { 5, "Survivors are hardened individuals who have endured countless trials and emerged stronger from the crucible of adversity. They possess unwavering determination and a resourceful nature. Survivors specialize in navigating dangerous environments, overcoming physical challenges, and outsmarting foes. With a focus on self-preservation, resilience, and adaptability, survivors excel at surviving in hostile territories, mastering survival skills, and finding creative solutions to seemingly insurmountable obstacles.", "Survivor" },
                    { 6, "Commanders are natural leaders who excel at taking charge and directing others with authority. They possess a commanding presence and the ability to inspire loyalty and respect from their subordinates. Commanders specialize in strategic planning, tactical decision-making, and mobilizing forces for battle. With a focus on leadership, coordination, and strategic thinking, commanders excel at organizing troops, devising battle strategies, and effectively deploying resources to achieve victory on the battlefield. They instill discipline and unity among their ranks, becoming the driving force behind the realm's military campaigns and ensuring the success of their missions.", "Commander" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
