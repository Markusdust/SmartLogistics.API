﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartLogistics.API.DataModels;

#nullable disable

namespace SmartLogistics.API.Migrations
{
    [DbContext(typeof(SmartLogisticsContext))]
    partial class SmartLogisticsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartLogistics.API.DataModels.Adresse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hausnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KundeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrtId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Strasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KundeId")
                        .IsUnique();

                    b.ToTable("Adressen");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Bestellung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Erfassdatum")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("KundenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LieferungEnde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LieferungStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bestellungen");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Geschlecht", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Geschlechter");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Kunde", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Geburtsdatum")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GeschlechtId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeschlechtId");

                    b.ToTable("Kunden");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Lagerverwaltung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Menge")
                        .HasColumnType("int");

                    b.Property<Guid>("ProduktId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.ToTable("Lagerverwaltung");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Lieferung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BestellId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Lieferart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priorität")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lieferungen");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Ort", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ortschaft")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Postleitzahl")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orte");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Produkt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Produkte");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Roboter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roboter");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Adresse", b =>
                {
                    b.HasOne("SmartLogistics.API.DataModels.Kunde", null)
                        .WithOne("Adresse")
                        .HasForeignKey("SmartLogistics.API.DataModels.Adresse", "KundeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Kunde", b =>
                {
                    b.HasOne("SmartLogistics.API.DataModels.Geschlecht", "Geschlecht")
                        .WithMany()
                        .HasForeignKey("GeschlechtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Geschlecht");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Lagerverwaltung", b =>
                {
                    b.HasOne("SmartLogistics.API.DataModels.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("SmartLogistics.API.DataModels.Kunde", b =>
                {
                    b.Navigation("Adresse")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
