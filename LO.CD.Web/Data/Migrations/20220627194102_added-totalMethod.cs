using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LO.CD.Web.Data.Migrations
{
    public partial class addedtotalMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Deals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Deals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
