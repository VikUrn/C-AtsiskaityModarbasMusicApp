﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAppDbContext.Migrations
{
    public partial class ManyToManyRelationshipAddedUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WishListId",
                table: "WishList",
                type: "int",
                nullable: false,
                defaultValueSql: "INT",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WishListId",
                table: "WishList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "INT");
        }
    }
}
