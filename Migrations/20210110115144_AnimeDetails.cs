using Microsoft.EntityFrameworkCore.Migrations;

namespace Sorea_Stefania_Proiect.Migrations
{
    public partial class AnimeDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Seasons",
                table: "Anime",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Studio",
                table: "Anime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Seasons",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Studio",
                table: "Anime");
        }
    }
}
