using Microsoft.EntityFrameworkCore.Migrations;

namespace tsx_react_project.Migrations
{
    public partial class addedRelationalIDFromStoneToJewelry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabs_JewelryPieces_jewelryId",
                table: "Cabs");

            migrationBuilder.DropIndex(
                name: "IX_Cabs_jewelryId",
                table: "Cabs");

            migrationBuilder.AddColumn<int>(
                name: "StoneId",
                table: "JewelryPieces",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JewelryPieces_StoneId",
                table: "JewelryPieces",
                column: "StoneId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryPieces_Cabs_StoneId",
                table: "JewelryPieces",
                column: "StoneId",
                principalTable: "Cabs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JewelryPieces_Cabs_StoneId",
                table: "JewelryPieces");

            migrationBuilder.DropIndex(
                name: "IX_JewelryPieces_StoneId",
                table: "JewelryPieces");

            migrationBuilder.DropColumn(
                name: "StoneId",
                table: "JewelryPieces");

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
