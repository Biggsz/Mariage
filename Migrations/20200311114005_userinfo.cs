using Microsoft.EntityFrameworkCore.Migrations;

namespace Mariage.Migrations
{
    public partial class userinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInvitedToLunch",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PlusOne",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WillAttendDinner",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WillAttendLunch",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInvitedToLunch",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlusOne",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WillAttendDinner",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WillAttendLunch",
                table: "AspNetUsers");
        }
    }
}
