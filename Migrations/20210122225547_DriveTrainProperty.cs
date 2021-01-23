using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPro.Migrations
{
    public partial class DriveTrainProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is4WD",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "DriveTrain",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriveTrain",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "is4WD",
                table: "Cars",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
