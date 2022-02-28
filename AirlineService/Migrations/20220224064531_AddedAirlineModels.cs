using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineService.Migrations
{
    public partial class AddedAirlineModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirlineInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AirlineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledDays = table.Column<short>(type: "smallint", nullable: false),
                    InstrumentUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    NonBusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    NumberOfRows = table.Column<int>(type: "int", nullable: false),
                    Meals = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirlineInventories_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirlineInventories_AirlineId",
                table: "AirlineInventories",
                column: "AirlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineInventories");

            migrationBuilder.DropTable(
                name: "Airlines");
        }
    }
}
