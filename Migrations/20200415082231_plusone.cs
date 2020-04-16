using Microsoft.EntityFrameworkCore.Migrations;

namespace Mariage.Migrations
{
    public partial class plusone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlusOne",
                table: "Participations");

            migrationBuilder.AddColumn<int>(
                name: "PlusOneId",
                table: "Participations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_PlusOneId",
                table: "Participations",
                column: "PlusOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Participations_PlusOneId",
                table: "Participations",
                column: "PlusOneId",
                principalTable: "Participations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Participations_PlusOneId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_PlusOneId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "PlusOneId",
                table: "Participations");

            migrationBuilder.AddColumn<string>(
                name: "PlusOne",
                table: "Participations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
