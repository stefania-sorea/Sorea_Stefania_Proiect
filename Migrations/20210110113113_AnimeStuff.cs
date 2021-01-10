using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sorea_Stefania_Proiect.Migrations
{
    public partial class AnimeStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Character",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Character",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeID",
                table: "Character",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeName = table.Column<string>(nullable: true),
                    DebutDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_AnimeID",
                table: "Character",
                column: "AnimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Anime_AnimeID",
                table: "Character",
                column: "AnimeID",
                principalTable: "Anime",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Anime_AnimeID",
                table: "Character");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropIndex(
                name: "IX_Character_AnimeID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "AnimeID",
                table: "Character");

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Character",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
