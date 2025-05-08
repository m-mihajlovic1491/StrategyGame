using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrategyGame.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DefensePercentage = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Armor__3214EC076A9415A6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Item__3214EC0785D3B0CE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Legion__3214EC07A9651F52", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Damage = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Monster__3214EC078720EC3B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Damage = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Weapon__3214EC07D51BCEBC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LegionId = table.Column<int>(type: "int", nullable: true),
                    EquippedArmor = table.Column<int>(type: "int", nullable: true),
                    EquippedWeapon = table.Column<int>(type: "int", nullable: true),
                    Health = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 100m),
                    IsDead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hero__3214EC076E97809B", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hero_Armor",
                        column: x => x.EquippedArmor,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Hero_Legion",
                        column: x => x.LegionId,
                        principalTable: "Legion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Hero_Weapon",
                        column: x => x.EquippedWeapon,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Backpack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Backpack__3214EC07514A6DB0", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Backpack_Hero",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BackPackItem",
                columns: table => new
                {
                    BackPackId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BackPack__3759BBF93E100BE8", x => new { x.BackPackId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_BackPackItem_Backpack",
                        column: x => x.BackPackId,
                        principalTable: "Backpack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackPackItem_Item",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Backpack_Heroid",
                table: "Backpack",
                column: "HeroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BackPackItem_ItemId",
                table: "BackPackItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_EquippedArmor",
                table: "Hero",
                column: "EquippedArmor");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_EquippedWeapon",
                table: "Hero",
                column: "EquippedWeapon");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_LegionId",
                table: "Hero",
                column: "LegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackPackItem");

            migrationBuilder.DropTable(
                name: "Monster");

            migrationBuilder.DropTable(
                name: "Backpack");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropTable(
                name: "Legion");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
