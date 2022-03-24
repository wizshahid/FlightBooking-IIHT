using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineService.Migrations
{
    public partial class ConsolidatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirlineInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AirlineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirlineInventories_Airports_FromPlaceId",
                        column: x => x.FromPlaceId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirlineInventories_Airports_ToPlaceId",
                        column: x => x.ToPlaceId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "New Delhi", "Indira Gandhi International Airport" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Bengaluru", "Kempegowda International Airport" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Mumbai", "Chhatrapati Shivaji International Airport" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Chennai", "Chennai International Airport" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Srinagar", "Sheikh ul-Alam International Airport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirlineInventories_AirlineId",
                table: "AirlineInventories",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineInventories_FromPlaceId",
                table: "AirlineInventories",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineInventories_ToPlaceId",
                table: "AirlineInventories",
                column: "ToPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineInventories");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
