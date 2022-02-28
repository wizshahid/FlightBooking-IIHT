using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineService.Migrations
{
    public partial class AirportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirlineInventories_Airlines_AirlineId",
                table: "AirlineInventories");

            migrationBuilder.DropColumn(
                name: "FromPlace",
                table: "AirlineInventories");

            migrationBuilder.DropColumn(
                name: "ToPlace",
                table: "AirlineInventories");

            migrationBuilder.AddColumn<Guid>(
                name: "FromPlaceId",
                table: "AirlineInventories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ToPlaceId",
                table: "AirlineInventories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_AirlineInventories_FromPlaceId",
                table: "AirlineInventories",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineInventories_ToPlaceId",
                table: "AirlineInventories",
                column: "ToPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirlineInventories_Airlines_AirlineId",
                table: "AirlineInventories",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AirlineInventories_Airports_FromPlaceId",
                table: "AirlineInventories",
                column: "FromPlaceId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AirlineInventories_Airports_ToPlaceId",
                table: "AirlineInventories",
                column: "ToPlaceId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirlineInventories_Airlines_AirlineId",
                table: "AirlineInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_AirlineInventories_Airports_FromPlaceId",
                table: "AirlineInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_AirlineInventories_Airports_ToPlaceId",
                table: "AirlineInventories");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_AirlineInventories_FromPlaceId",
                table: "AirlineInventories");

            migrationBuilder.DropIndex(
                name: "IX_AirlineInventories_ToPlaceId",
                table: "AirlineInventories");

            migrationBuilder.DropColumn(
                name: "FromPlaceId",
                table: "AirlineInventories");

            migrationBuilder.DropColumn(
                name: "ToPlaceId",
                table: "AirlineInventories");

            migrationBuilder.AddColumn<string>(
                name: "FromPlace",
                table: "AirlineInventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToPlace",
                table: "AirlineInventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AirlineInventories_Airlines_AirlineId",
                table: "AirlineInventories",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
