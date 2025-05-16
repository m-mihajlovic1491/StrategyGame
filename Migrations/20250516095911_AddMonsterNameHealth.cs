using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrategyGame.Migrations
{
    /// <inheritdoc />
    public partial class AddMonsterNameHealth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Defense",
                table: "Monster",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Monster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Monster");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Monster");
        }
    }
}
