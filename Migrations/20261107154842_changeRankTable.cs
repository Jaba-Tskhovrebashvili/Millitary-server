using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillitaryService.Migrations
{
    /// <inheritdoc />
    public partial class changeRankTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Ranks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ranks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
