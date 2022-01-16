using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAppDbContext.Migrations
{
    public partial class UpdatedMusicId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Musics",
                newName: "MusicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MusicId",
                table: "Musics",
                newName: "Id");
        }
    }
}
