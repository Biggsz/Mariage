using Microsoft.EntityFrameworkCore.Migrations;

namespace Mariage.Migrations
{
    public partial class completedform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CompletedForm",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedForm",
                table: "AspNetUsers");
        }
    }
}
