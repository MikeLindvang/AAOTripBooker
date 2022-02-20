using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAOTripBooker.Migrations
{
    public partial class Twowayforeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverPeriods_Drivers_DriverId",
                table: "DriverPeriods");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "DriverPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverPeriods_Drivers_DriverId",
                table: "DriverPeriods",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverPeriods_Drivers_DriverId",
                table: "DriverPeriods");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "DriverPeriods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverPeriods_Drivers_DriverId",
                table: "DriverPeriods",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }
    }
}
