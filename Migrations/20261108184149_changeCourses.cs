using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillitaryService.Migrations
{
    /// <inheritdoc />
    public partial class changeCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits");

            migrationBuilder.RenameColumn(
                name: "DurationInDays",
                table: "Courses",
                newName: "DurationInWeeks");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits",
                column: "ParentUnitId",
                principalTable: "MilitaryUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits");

            migrationBuilder.RenameColumn(
                name: "DurationInWeeks",
                table: "Courses",
                newName: "DurationInDays");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits",
                column: "ParentUnitId",
                principalTable: "MilitaryUnits",
                principalColumn: "Id");
        }
    }
}
