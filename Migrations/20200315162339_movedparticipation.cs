using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mariage.Migrations
{
    public partial class movedparticipation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBringChildren",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CanBringPlusOne",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompletedForm",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsInvitedToLunch",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
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

            migrationBuilder.AddColumn<int>(
                name: "ParticipationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CanBringChildren = table.Column<bool>(nullable: false),
                    CanBringPlusOne = table.Column<bool>(nullable: false),
                    CompletedForm = table.Column<bool>(nullable: false),
                    IsInvitedToLunch = table.Column<bool>(nullable: false),
                    WillAttendLunch = table.Column<bool>(nullable: false),
                    WillAttendDinner = table.Column<bool>(nullable: false),
                    PlusOne = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Participations_ParticipationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParticipationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParticipationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "CanBringChildren",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanBringPlusOne",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompletedForm",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInvitedToLunch",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlusOne",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WillAttendDinner",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WillAttendLunch",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
