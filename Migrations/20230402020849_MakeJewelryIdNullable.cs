using Microsoft.EntityFrameworkCore.Migrations;

namespace tsx_react_project.Migrations
{
    public partial class MakeJewelryIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabs_JewelryPieces_jewelryId",
                table: "Cabs");

            migrationBuilder.AlterColumn<int>(
                name: "jewelryId",
                table: "Cabs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabs_JewelryPieces_jewelryId",
                table: "Cabs",
                column: "jewelryId",
                principalTable: "JewelryPieces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabs_JewelryPieces_jewelryId",
                table: "Cabs");

            migrationBuilder.AlterColumn<int>(
                name: "jewelryId",
                table: "Cabs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabs_JewelryPieces_jewelryId",
                table: "Cabs",
                column: "jewelryId",
                principalTable: "JewelryPieces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
