using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAOTripBooker.Migrations
{
    public partial class driverPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverPeriods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverPeriods");
        }
    }
}
