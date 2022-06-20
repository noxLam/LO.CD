using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LO.CD.Web.Data.Migrations
{
    public partial class thirdtry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CarId",
                table: "Deals",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Cars_CarId",
                table: "Deals",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Cars_CarId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_CarId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Deals");
        }
    }
}
