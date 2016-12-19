﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HoneymoonShop.Models;

namespace HoneymoonShop.Migrations
{
    [DbContext(typeof(HoneyMoonShopContext))]
    partial class HoneyMoonShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoneymoonShop.Models.Accessoire", b =>
                {
                    b.Property<int>("AccessoireId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categorie");

                    b.Property<string>("Geslacht");

                    b.Property<string>("LinkNaarWebshop");

                    b.Property<string>("Merk");

                    b.HasKey("AccessoireId");

                    b.ToTable("Accessoire");
                });

            modelBuilder.Entity("HoneymoonShop.Models.AccessoireAfbeeldingen", b =>
                {
                    b.Property<string>("AccessoireAfbeelding")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessoireId");

                    b.Property<string>("SourceLocation");

                    b.HasKey("AccessoireAfbeelding");

                    b.HasAlternateKey("AccessoireId");

                    b.ToTable("AccessoireAfbeeldingenen");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Afspraak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Achternaam");

                    b.Property<DateTime>("DatumTijd");

                    b.Property<string>("EmailAdres");

                    b.Property<string>("SoortAfspraak");

                    b.Property<int>("TelefoonNummer");

                    b.Property<DateTime>("Trouwdatum");

                    b.Property<string>("Voornaam");

                    b.HasKey("Id");

                    b.ToTable("Afspraak");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Kleding", b =>
                {
                    b.Property<int>("Artikelnummer")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Kleding_type")
                        .IsRequired();

                    b.Property<string>("Merk");

                    b.Property<string>("Omschrijving");

                    b.Property<int>("Prijs");

                    b.HasKey("Artikelnummer");

                    b.ToTable("Kleding");

                    b.HasDiscriminator<string>("Kleding_type").HasValue("Kleding");
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingAccessoire", b =>
                {
                    b.Property<int>("Artikelnummer");

                    b.Property<int>("AccessoireId");

                    b.HasKey("Artikelnummer", "AccessoireId");

                    b.HasIndex("AccessoireId");

                    b.ToTable("KledingAccessoire");
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingAfbeeldingen", b =>
                {
                    b.Property<int>("Artikelnummer");

                    b.Property<string>("KledingAfbeelding")
                        .IsRequired();

                    b.Property<string>("SourceLocation");

                    b.HasKey("Artikelnummer");

                    b.HasAlternateKey("KledingAfbeelding");

                    b.ToTable("KledingAfbeeldingenen");
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingAfspraak", b =>
                {
                    b.Property<int>("Artikelnummer");

                    b.Property<int>("Id");

                    b.HasKey("Artikelnummer", "Id");

                    b.HasIndex("Id");

                    b.ToTable("KledingAfspraak");
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingKleuren", b =>
                {
                    b.Property<int>("Artikelnummer");

                    b.Property<string>("KledingKleur")
                        .IsRequired();

                    b.HasKey("Artikelnummer");

                    b.HasAlternateKey("KledingKleur");

                    b.ToTable("KledingKleurenen");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Jurk", b =>
                {
                    b.HasBaseType("HoneymoonShop.Models.Kleding");

                    b.Property<string>("Materiaal");

                    b.Property<string>("Neklijn");

                    b.Property<string>("Silhouette");

                    b.Property<string>("Stijl");

                    b.ToTable("Jurk");

                    b.HasDiscriminator().HasValue("Kleding_jurk");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Pak", b =>
                {
                    b.HasBaseType("HoneymoonShop.Models.Kleding");

                    b.Property<string>("Model");

                    b.ToTable("Pak");

                    b.HasDiscriminator().HasValue("Kleding_pak");
                });

            modelBuilder.Entity("HoneymoonShop.Models.AccessoireAfbeeldingen", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Accessoire", "Accessoire")
                        .WithMany("AccessoireAfbeeldingen")
                        .HasForeignKey("AccessoireId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingAccessoire", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Accessoire", "Accessoire")
                        .WithMany("KledingAccessoires")
                        .HasForeignKey("AccessoireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Kleding", "Kleding")
                        .WithMany("KledingAccessoires")
                        .HasForeignKey("Artikelnummer")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingAfbeeldingen", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Kleding", "Kleding")
                        .WithMany("KledingAfbeeldingen")
                        .HasForeignKey("Artikelnummer")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingAfspraak", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Kleding", "Kleding")
                        .WithMany("KledingAfspraken")
                        .HasForeignKey("Artikelnummer")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Afspraak", "Afspraak")
                        .WithMany("KledingAfspraken")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.KledingKleuren", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Kleding", "Kleding")
                        .WithMany("KledingKleuren")
                        .HasForeignKey("Artikelnummer")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}