using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frands.Migrations
{
    public partial class MySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumName",
                table: "Track");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Track",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TracksHref",
                table: "Track",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlbumName",
                table: "Album",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlbumsHref",
                table: "Album",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "TracksHref",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "AlbumName",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "AlbumsHref",
                table: "Album");

            migrationBuilder.AddColumn<string>(
                name: "AlbumName",
                table: "Track",
                nullable: true);
        }
    }
}
