using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrategyGame.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexHeroName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Hero_Name",
                table: "Hero",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hero_Name",
                table: "Hero");
        }
    }
}
