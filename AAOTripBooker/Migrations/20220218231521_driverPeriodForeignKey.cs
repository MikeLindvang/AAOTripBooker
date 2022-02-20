using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAOTripBooker.Migrations
{
    public partial class driverPeriodForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
