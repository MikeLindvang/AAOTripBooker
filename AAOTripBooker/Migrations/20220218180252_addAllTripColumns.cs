using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAOTripBooker.Migrations
{
    public partial class addAllTripColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Traffic",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Traffic",
                table: "Trips");
        }
    }
}
