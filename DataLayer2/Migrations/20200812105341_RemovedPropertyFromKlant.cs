using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class RemovedPropertyFromKlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AantalReservatiesDitJaar",
                table: "Klanten");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AantalReservatiesDitJaar",
                table: "Klanten",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
