using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillitaryService.Migrations
{
    /// <inheritdoc />
    public partial class changeMilitaryUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentUnitId1",
                table: "MilitaryUnits",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnits_ParentUnitId1",
                table: "MilitaryUnits",
                column: "ParentUnitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId1",
                table: "MilitaryUnits",
                column: "ParentUnitId1",
                principalTable: "MilitaryUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId1",
                table: "MilitaryUnits");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnits_ParentUnitId1",
                table: "MilitaryUnits");

            migrationBuilder.DropColumn(
                name: "ParentUnitId1",
                table: "MilitaryUnits");
        }
    }
}
