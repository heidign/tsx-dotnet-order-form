using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace tsx_react_project.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    shape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "JewelryPieces",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    piece = table.Column<int>(type: "integer", nullable: false),
                    material = table.Column<int>(type: "integer", nullable: false),
                    stoneid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryPieces", x => x.id);
                    table.ForeignKey(
                        name: "FK_JewelryPieces_Cabs_stoneid",
                        column: x => x.stoneid,
                        principalTable: "Cabs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JewelryPieces_stoneid",
                table: "JewelryPieces",
                column: "stoneid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JewelryPieces");

            migrationBuilder.DropTable(
                name: "Cabs");
        }
    }
}
