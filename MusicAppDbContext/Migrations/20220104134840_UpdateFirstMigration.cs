using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAppDbContext.Migrations
{
    public partial class UpdateFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "Musics",
                newName: "Genre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Musics",
                newName: "SongId");
        }
    }
}
