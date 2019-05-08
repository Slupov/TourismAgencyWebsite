using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatinloAdventures.Data.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageComments_AspNetUsers_UserId1",
                table: "TourPackageComments");

            migrationBuilder.DropIndex(
                name: "IX_TourPackageComments_UserId1",
                table: "TourPackageComments");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "TourPackageComments",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TourPackageComments",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TourPackageComments",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 19, 17, 34, 933, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 18, 58, 3, 131, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "TourPackageComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 19, 17, 34, 924, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 18, 58, 3, 121, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_TourPackageComments_UserId",
                table: "TourPackageComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackageComments_AspNetUsers_UserId",
                table: "TourPackageComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageComments_AspNetUsers_UserId",
                table: "TourPackageComments");

            migrationBuilder.DropIndex(
                name: "IX_TourPackageComments_UserId",
                table: "TourPackageComments");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "TourPackageComments",
                newName: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TourPackageComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TourPackageComments",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 18, 58, 3, 131, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 19, 17, 34, 933, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "TourPackageComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 18, 58, 3, 121, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 19, 17, 34, 924, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_TourPackageComments_UserId1",
                table: "TourPackageComments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackageComments_AspNetUsers_UserId1",
                table: "TourPackageComments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
