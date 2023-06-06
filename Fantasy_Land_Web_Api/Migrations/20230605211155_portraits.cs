using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyLandWebApi.Migrations
{
    /// <inheritdoc />
    public partial class portraits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portraits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portraits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portraits");
        }
    }
}
