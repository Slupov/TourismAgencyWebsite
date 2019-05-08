using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatinloAdventures.Data.Migrations
{
    public partial class addedTourPackageComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 18, 58, 3, 121, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 13, 34, 2, 490, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "TourPackageComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId1 = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true, defaultValue: ""),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 1, 12, 18, 58, 3, 131, DateTimeKind.Local))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPackageComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourPackageComments_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourPackageComments_UserId1",
                table: "TourPackageComments",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourPackageComments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 12, 13, 34, 2, 490, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 12, 18, 58, 3, 121, DateTimeKind.Local));
        }
    }
}
