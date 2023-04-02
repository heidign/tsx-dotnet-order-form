using Microsoft.EntityFrameworkCore.Migrations;

namespace tsx_react_project.Migrations
{
    public partial class ChangedFKToStone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JewelryPieces_Cabs_stoneId",
                table: "JewelryPieces");

            migrationBuilder.DropIndex(
                name: "IX_JewelryPieces_stoneId",
                table: "JewelryPieces");

            migrationBuilder.DropColumn(
                name: "stoneId",
                table: "JewelryPieces");

            migrationBuilder.AddColumn<int>(
                name: "jewelryId",
                table: "Cabs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cabs_jewelryId",
                table: "Cabs",
                column: "jewelryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabs_JewelryPieces_jewelryId",
                table: "Cabs",
                column: "jewelryId",
                principalTable: "JewelryPieces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabs_JewelryPieces_jewelryId",
                table: "Cabs");

            migrationBuilder.DropIndex(
                name: "IX_Cabs_jewelryId",
                table: "Cabs");

            migrationBuilder.DropColumn(
                name: "jewelryId",
                table: "Cabs");

            migrationBuilder.AddColumn<int>(
                name: "stoneId",
                table: "JewelryPieces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JewelryPieces_stoneId",
                table: "JewelryPieces",
                column: "stoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryPieces_Cabs_stoneId",
                table: "JewelryPieces",
                column: "stoneId",
                principalTable: "Cabs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
