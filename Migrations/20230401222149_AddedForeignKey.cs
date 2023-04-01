using Microsoft.EntityFrameworkCore.Migrations;

namespace tsx_react_project.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JewelryPieces_Cabs_stoneid",
                table: "JewelryPieces");

            migrationBuilder.RenameColumn(
                name: "stoneid",
                table: "JewelryPieces",
                newName: "cabs");

            migrationBuilder.RenameIndex(
                name: "IX_JewelryPieces_stoneid",
                table: "JewelryPieces",
                newName: "IX_JewelryPieces_cabs");

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryPieces_Cabs_cabs",
                table: "JewelryPieces",
                column: "cabs",
                principalTable: "Cabs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JewelryPieces_Cabs_cabs",
                table: "JewelryPieces");

            migrationBuilder.RenameColumn(
                name: "cabs",
                table: "JewelryPieces",
                newName: "stoneid");

            migrationBuilder.RenameIndex(
                name: "IX_JewelryPieces_cabs",
                table: "JewelryPieces",
                newName: "IX_JewelryPieces_stoneid");

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryPieces_Cabs_stoneid",
                table: "JewelryPieces",
                column: "stoneid",
                principalTable: "Cabs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
