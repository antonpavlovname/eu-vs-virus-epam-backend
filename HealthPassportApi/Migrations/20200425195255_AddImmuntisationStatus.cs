using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmunisationPass.Migrations
{
    public partial class AddImmuntisationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImmuntisationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Uuid = table.Column<Guid>(nullable: false),
                    ImmuneType = table.Column<string>(nullable: true),
                    Tested = table.Column<bool>(nullable: false),
                    CertBody = table.Column<string>(nullable: true),
                    CertDate = table.Column<DateTime>(nullable: false),
                    CertExpiry = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmuntisationStatus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImmuntisationStatus");
        }
    }
}
