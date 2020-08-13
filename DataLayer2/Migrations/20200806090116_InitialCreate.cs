using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    KlantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    VoorNaam = table.Column<string>(nullable: true),
                    BtwNummer = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Straat = table.Column<string>(nullable: true),
                    HuisNummer = table.Column<string>(nullable: true),
                    BusNr = table.Column<string>(nullable: true),
                    AantalReservatiesDitJaar = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.KlantID);
                });

            migrationBuilder.CreateTable(
                name: "Vloot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    EersteUur = table.Column<decimal>(nullable: false),
                    NightLife = table.Column<decimal>(nullable: false),
                    Wedding = table.Column<decimal>(nullable: false),
                    Wellness = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vloot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reservaties",
                columns: table => new
                {
                    ReservatieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantID = table.Column<int>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    OphaalLocatie = table.Column<int>(nullable: false),
                    AfzetLocatie = table.Column<int>(nullable: false),
                    GereserveerdeVoertuigId = table.Column<int>(nullable: true),
                    Arrangement = table.Column<int>(nullable: false),
                    AantalUren = table.Column<int>(nullable: false),
                    Subtotaal = table.Column<decimal>(nullable: false),
                    AangerekendeKortingen = table.Column<decimal>(nullable: false),
                    TotaalExclusiefBtw = table.Column<decimal>(nullable: false),
                    BtwBedrag = table.Column<decimal>(nullable: false),
                    TeBetalenBedrag = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaties", x => x.ReservatieId);
                    table.ForeignKey(
                        name: "FK_reservaties_Vloot_GereserveerdeVoertuigId",
                        column: x => x.GereserveerdeVoertuigId,
                        principalTable: "Vloot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservaties_Klanten_KlantID",
                        column: x => x.KlantID,
                        principalTable: "Klanten",
                        principalColumn: "KlantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservaties_GereserveerdeVoertuigId",
                table: "reservaties",
                column: "GereserveerdeVoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_reservaties_KlantID",
                table: "reservaties",
                column: "KlantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservaties");

            migrationBuilder.DropTable(
                name: "Vloot");

            migrationBuilder.DropTable(
                name: "Klanten");
        }
    }
}
