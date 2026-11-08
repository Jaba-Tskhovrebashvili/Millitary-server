using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillitaryService.Migrations
{
    /// <inheritdoc />
    public partial class changeMilitaryUnits1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "ParentUnitId",
                table: "MilitaryUnits",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits",
                column: "ParentUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits",
                column: "ParentUnitId",
                principalTable: "MilitaryUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnits_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnits_ParentUnitId",
                table: "MilitaryUnits");

            migrationBuilder.AlterColumn<int>(
                name: "ParentUnitId",
                table: "MilitaryUnits",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
    }
}
