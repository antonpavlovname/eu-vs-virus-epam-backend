using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthPassportApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiseaseDescriptions",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Symptoms = table.Column<string>(nullable: true),
                    Treatment = table.Column<string>(nullable: true),
                    Vaccination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseDescriptions", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "UsefulReferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    DiseaseDescriptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsefulReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsefulReferences_DiseaseDescriptions_DiseaseDescriptionName",
                        column: x => x.DiseaseDescriptionName,
                        principalTable: "DiseaseDescriptions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsefulReferences_DiseaseDescriptionName",
                table: "UsefulReferences",
                column: "DiseaseDescriptionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsefulReferences");

            migrationBuilder.DropTable(
                name: "DiseaseDescriptions");
        }
    }
}
