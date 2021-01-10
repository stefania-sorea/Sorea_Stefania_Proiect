using Microsoft.EntityFrameworkCore.Migrations;

namespace Sorea_Stefania_Proiect.Migrations
{
    public partial class VoiceActorsLang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "VoiceActor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "VoiceActor");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
