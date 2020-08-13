﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(ReservatieContext))]
    [Migration("20200812105341_RemovedPropertyFromKlant")]
    partial class RemovedPropertyFromKlant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainLibrary.Klant", b =>
                {
                    b.Property<int>("KlantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BtwNummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("KlantID");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("DomainLibrary.Reservatie", b =>
                {
                    b.Property<int>("ReservatieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AangerekendeKortingen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AantalUren")
                        .HasColumnType("int");

                    b.Property<int>("AfzetLocatie")
                        .HasColumnType("int");

                    b.Property<int>("Arrangement")
                        .HasColumnType("int");

                    b.Property<DateTime>("AutoBinnenGebracht")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("BtwBedrag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GereserveerdeVoertuigId")
                        .HasColumnType("int");

                    b.Property<int?>("KlantID")
                        .HasColumnType("int");

                    b.Property<int>("OphaalLocatie")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotaal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TeBetalenBedrag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotaalExclusiefBtw")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservatieId");

                    b.HasIndex("GereserveerdeVoertuigId");

                    b.HasIndex("KlantID");

                    b.ToTable("reservaties");
                });

            modelBuilder.Entity("DomainLibrary.Voertuig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("EersteUur")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NightLife")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Wedding")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Wellness")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Vloot");
                });

            modelBuilder.Entity("DomainLibrary.Reservatie", b =>
                {
                    b.HasOne("DomainLibrary.Voertuig", "GereserveerdeVoertuig")
                        .WithMany()
                        .HasForeignKey("GereserveerdeVoertuigId");

                    b.HasOne("DomainLibrary.Klant", "klant")
                        .WithMany()
                        .HasForeignKey("KlantID");
                });
#pragma warning restore 612, 618
        }
    }
}
