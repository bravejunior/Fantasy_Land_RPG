using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class capabilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
