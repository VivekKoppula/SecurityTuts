using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterUserEmailService.Migrations
{
    public partial class AddMoreInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RollNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearEnrolled",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RollNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "YearEnrolled",
                table: "AspNetUsers");
        }
    }
}
