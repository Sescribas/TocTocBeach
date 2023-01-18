using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TocTocBeach.Migrations
{
    public partial class createrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeachResorts_BeachResortInfoId",
                table: "BeachResorts",
                column: "BeachResortInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeachResorts_BeachResortsInfo_BeachResortInfoId",
                table: "BeachResorts",
                column: "BeachResortInfoId",
                principalTable: "BeachResortsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachResorts_BeachResortsInfo_BeachResortInfoId",
                table: "BeachResorts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BeachResorts_BeachResortInfoId",
                table: "BeachResorts");
        }
    }
}
