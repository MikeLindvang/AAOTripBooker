using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAOTripBooker.Migrations
{
    public partial class moreTripping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StartLocation",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Urgent",
                table: "Trips",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartLocation",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Urgent",
                table: "Trips");
        }
    }
}
