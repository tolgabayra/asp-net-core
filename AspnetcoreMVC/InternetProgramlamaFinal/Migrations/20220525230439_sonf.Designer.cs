﻿// <auto-generated />
using System;
using InternetProgramlamaFinal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InternetProgramlamaFinal.Migrations
{
    [DbContext(typeof(TableContext))]
    [Migration("20220525230439_sonf")]
    partial class sonf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Egitmenler", b =>
                {
                    b.Property<int>("EgitmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EgitmenAdi")
                        .HasColumnType("text");

                    b.Property<string>("EgitmenFoto")
                        .HasColumnType("text");

                    b.Property<int?>("KursId")
                        .HasColumnType("integer");

                    b.HasKey("EgitmenId");

                    b.HasIndex("KursId");

                    b.ToTable("Egitmenlers");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Etkinlikler", b =>
                {
                    b.Property<int>("EtkinlikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EtkinlikAdi")
                        .HasColumnType("text");

                    b.Property<DateTime>("EtkinlikZamani")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("SalonId")
                        .HasColumnType("integer");

                    b.HasKey("EtkinlikId");

                    b.HasIndex("SalonId");

                    b.ToTable("Etkinliklers");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Kurslar", b =>
                {
                    b.Property<int>("KursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EgitmenId")
                        .HasColumnType("integer");

                    b.Property<string>("KursAciklama")
                        .HasColumnType("text");

                    b.Property<string>("KursAdi")
                        .HasColumnType("text");

                    b.Property<double>("KursFiyati")
                        .HasColumnType("double precision");

                    b.Property<string>("KursFotografi")
                        .HasColumnType("text");

                    b.Property<string>("KursSeanslari")
                        .HasColumnType("text");

                    b.Property<int?>("SalonId")
                        .HasColumnType("integer");

                    b.Property<int?>("SalonlarsSalonId")
                        .HasColumnType("integer");

                    b.HasKey("KursId");

                    b.HasIndex("SalonlarsSalonId");

                    b.ToTable("Kurslars");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Salonlar", b =>
                {
                    b.Property<int>("SalonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("SalonAdi")
                        .HasColumnType("text");

                    b.Property<string>("SalonKonumu")
                        .HasColumnType("text");

                    b.HasKey("SalonId");

                    b.ToTable("Salonlars");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Uyeler", b =>
                {
                    b.Property<int>("UyeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EgitmenId")
                        .HasColumnType("integer");

                    b.Property<int?>("KursId")
                        .HasColumnType("integer");

                    b.Property<string>("UyeAdi")
                        .HasColumnType("text");

                    b.Property<string>("UyeSoyadi")
                        .HasColumnType("text");

                    b.Property<string>("UyeTelefon")
                        .HasColumnType("text");

                    b.HasKey("UyeId");

                    b.HasIndex("EgitmenId");

                    b.HasIndex("KursId");

                    b.ToTable("Uyelers");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Egitmenler", b =>
                {
                    b.HasOne("InternetProgramlamaFinal.Models.Kurslar", "Kurslars")
                        .WithMany("Egitmenlers")
                        .HasForeignKey("KursId");

                    b.Navigation("Kurslars");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Etkinlikler", b =>
                {
                    b.HasOne("InternetProgramlamaFinal.Models.Salonlar", "Salonlars")
                        .WithMany()
                        .HasForeignKey("SalonId");

                    b.Navigation("Salonlars");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Kurslar", b =>
                {
                    b.HasOne("InternetProgramlamaFinal.Models.Salonlar", "Salonlars")
                        .WithMany()
                        .HasForeignKey("SalonlarsSalonId");

                    b.Navigation("Salonlars");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Uyeler", b =>
                {
                    b.HasOne("InternetProgramlamaFinal.Models.Egitmenler", "Egitmenlers")
                        .WithMany()
                        .HasForeignKey("EgitmenId");

                    b.HasOne("InternetProgramlamaFinal.Models.Kurslar", null)
                        .WithMany("Uyelers")
                        .HasForeignKey("EgitmenId");

                    b.HasOne("InternetProgramlamaFinal.Models.Kurslar", "Kurslars")
                        .WithMany()
                        .HasForeignKey("KursId");

                    b.Navigation("Egitmenlers");

                    b.Navigation("Kurslars");
                });

            modelBuilder.Entity("InternetProgramlamaFinal.Models.Kurslar", b =>
                {
                    b.Navigation("Egitmenlers");

                    b.Navigation("Uyelers");
                });
#pragma warning restore 612, 618
        }
    }
}
