using Microsoft.EntityFrameworkCore.Migrations;

namespace tsx_react_project.Migrations
{
    public partial class ChangedStoneId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JewelryPieces_Cabs_cabs",
                table: "JewelryPieces");

            migrationBuilder.DropIndex(
                name: "IX_JewelryPieces_cabs",
                table: "JewelryPieces");

            migrationBuilder.DropColumn(
                name: "cabs",
                table: "JewelryPieces");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "cabs",
                table: "JewelryPieces",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JewelryPieces_cabs",
                table: "JewelryPieces",
                column: "cabs");

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryPieces_Cabs_cabs",
                table: "JewelryPieces",
                column: "cabs",
                principalTable: "Cabs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
