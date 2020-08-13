using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusNr",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "Gemeente",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "HuisNummer",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "Straat",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "VoorNaam",
                table: "Klanten");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Klanten",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Klanten");

            migrationBuilder.AddColumn<string>(
                name: "BusNr",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gemeente",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HuisNummer",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Straat",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoorNaam",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
