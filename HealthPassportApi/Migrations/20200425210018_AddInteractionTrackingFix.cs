using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmunisationPass.Migrations
{
    public partial class AddInteractionTrackingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uuid",
                table: "InteractionTracking",
                newName: "UserId"
                );

            migrationBuilder.AddColumn<Guid>(
                name: "InteractionEntity",
                table: "InteractionTracking",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InteractionEntity",
                table: "InteractionTracking");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "InteractionTracking",
                newName: "Uuid"
            );
        }
    }
}
