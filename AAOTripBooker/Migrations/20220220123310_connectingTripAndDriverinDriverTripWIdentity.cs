using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAOTripBooker.Migrations
{
    public partial class connectingTripAndDriverinDriverTripWIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverTrips",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverTrips", x => new { x.DriverId, x.TripId });
                    table.ForeignKey(
                        name: "FK_DriverTrips_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverTrips_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverTrips_TripId",
                table: "DriverTrips",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverTrips");
        }
    }
}
