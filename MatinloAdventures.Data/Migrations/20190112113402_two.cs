using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatinloAdventures.Data.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackages",
                table: "TourPackages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 13, 34, 2, 490, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 13, 30, 54, 485, DateTimeKind.Local));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackages",
                table: "TourPackages",
                columns: new[] { "Id", "Destination", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackages",
                table: "TourPackages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 13, 30, 54, 485, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 13, 34, 2, 490, DateTimeKind.Local));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackages",
                table: "TourPackages",
                columns: new[] { "Destination", "Name" });
        }
    }
}
