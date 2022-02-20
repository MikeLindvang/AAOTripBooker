using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAOTripBooker.Migrations
{
    public partial class DriverinDriverPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_DriverPeriods_DriverPeriodId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_DriverPeriodId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverPeriodId",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "DriverPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DriverPeriods_DriverId",
                table: "DriverPeriods",
                column: "DriverId");

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

            migrationBuilder.DropIndex(
                name: "IX_DriverPeriods_DriverId",
                table: "DriverPeriods");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "DriverPeriods");

            migrationBuilder.AddColumn<int>(
                name: "DriverPeriodId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_DriverPeriodId",
                table: "Drivers",
                column: "DriverPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_DriverPeriods_DriverPeriodId",
                table: "Drivers",
                column: "DriverPeriodId",
                principalTable: "DriverPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
