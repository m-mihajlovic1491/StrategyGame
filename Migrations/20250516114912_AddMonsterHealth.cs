using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrategyGame.Migrations
{
    /// <inheritdoc />
    public partial class AddMonsterHealth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Health",
                table: "Monster",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 100m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Health",
                table: "Monster");
        }
    }
}
