using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAppDbContext.Migrations
{
    public partial class ManyToManyRelationshipAddedUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WishList",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                newName: "IX_WishList_Id");

            migrationBuilder.AlterColumn<int>(
                name: "WishListId",
                table: "WishList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_Id",
                table: "WishList",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_Id",
                table: "WishList");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WishList",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_Id",
                table: "WishList",
                newName: "IX_WishList_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "WishListId",
                table: "WishList",
                type: "int",
                nullable: false,
                defaultValueSql: "INTEGER",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
