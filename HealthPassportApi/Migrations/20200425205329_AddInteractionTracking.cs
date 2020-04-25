using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace HealthPassportApi.Migrations
{
    public partial class AddInteractionTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InteractionTracking",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Uuid = table.Column<Guid>(nullable: false),
                    CheckInTime = table.Column<DateTime>(nullable: false),
                    CheckoutTime = table.Column<DateTime>(nullable: false),
                    CheckInType = table.Column<string>(nullable: false),
                    LatLong = table.Column<Point>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionTracking", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteractionTracking");
        }
    }
}
