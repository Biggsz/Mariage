using Microsoft.EntityFrameworkCore.Migrations;

namespace Mariage.Migrations
{
    public partial class UserInParticipation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Participations_ParticipationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParticipationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParticipationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Participations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_UserId",
                table: "Participations",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_AspNetUsers_UserId",
                table: "Participations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_AspNetUsers_UserId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_UserId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Participations");

            migrationBuilder.AddColumn<int>(
                name: "ParticipationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParticipationId",
                table: "AspNetUsers",
                column: "ParticipationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Participations_ParticipationId",
                table: "AspNetUsers",
                column: "ParticipationId",
                principalTable: "Participations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
