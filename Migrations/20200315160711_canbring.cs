using Microsoft.EntityFrameworkCore.Migrations;

namespace Mariage.Migrations
{
    public partial class canbring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBringChildren",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanBringPlusOne",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBringChildren",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CanBringPlusOne",
                table: "AspNetUsers");
        }
    }
}
