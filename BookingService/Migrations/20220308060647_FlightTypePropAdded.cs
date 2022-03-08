using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingService.Migrations
{
    public partial class FlightTypePropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightType",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightType",
                table: "Bookings");
        }
    }
}
