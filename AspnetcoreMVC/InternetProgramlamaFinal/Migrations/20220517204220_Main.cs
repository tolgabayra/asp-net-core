using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InternetProgramlamaFinal.Migrations
{
    public partial class Main : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salonlars",
                columns: table => new
                {
                    SalonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalonAdi = table.Column<string>(type: "text", nullable: true),
                    SalonKonumu = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salonlars", x => x.SalonId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Etkinliklers",
                columns: table => new
                {
                    EtkinlikId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EtkinlikAdi = table.Column<string>(type: "text", nullable: true),
                    EtkinlikZamani = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SalonId = table.Column<int>(type: "integer", nullable: false),
                    SalonlarsSalonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinliklers", x => x.EtkinlikId);
                    table.ForeignKey(
                        name: "FK_Etkinliklers_Salonlars_SalonlarsSalonId",
                        column: x => x.SalonId,
                        principalTable: "Salonlars",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kurslars",
                columns: table => new
                {
                    KursId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KursAdi = table.Column<string>(type: "text", nullable: true),
                    KursAciklama = table.Column<string>(type: "text", nullable: true),
                    KursFotografi = table.Column<string>(type: "text", nullable: true),
                    KursSeanslari = table.Column<string>(type: "text", nullable: true),
                    KursFiyati = table.Column<double>(type: "double precision", nullable: false),
                    SalonId = table.Column<int>(type: "integer", nullable: false),
                    EgitmenId = table.Column<int>(type: "integer", nullable: false),
                    SalonlarsSalonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurslars", x => x.KursId);
                    table.ForeignKey(
                        name: "FK_Kurslars_Salonlars_SalonlarsSalonId",
                        column: x => x.SalonId,
                        principalTable: "Salonlars",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Egitmenlers",
                columns: table => new
                {
                    EgitmenId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EgitmenAdi = table.Column<string>(type: "text", nullable: true),
                    EgitmenFoto = table.Column<string>(type: "text", nullable: true),
                    KursId = table.Column<int>(type: "integer", nullable: false),
                    KurslarsKursId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenlers", x => x.EgitmenId);
                    table.ForeignKey(
                        name: "FK_Egitmenlers_Kurslars_KurslarsKursId",
                        column: x => x.KursId,
                        principalTable: "Kurslars",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uyelers",
                columns: table => new
                {
                    UyeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UyeAdi = table.Column<string>(type: "text", nullable: true),
                    UyeSoyadi = table.Column<string>(type: "text", nullable: true),
                    UyeTelefon = table.Column<string>(type: "text", nullable: true),
                    KursId = table.Column<int>(type: "integer", nullable: false),
                    EgitmenId = table.Column<int>(type: "integer", nullable: false),
                    KurslarsKursId = table.Column<int>(type: "integer", nullable: true),
                    EgitmenlersEgitmenId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyelers", x => x.UyeId);
                    table.ForeignKey(
                        name: "FK_Uyelers_Egitmenlers_EgitmenlersEgitmenId",
                        column: x => x.EgitmenId,
                        principalTable: "Egitmenlers",
                        principalColumn: "EgitmenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uyelers_Kurslars_KurslarsKursId",
                        column: x => x.KursId,
                        principalTable: "Kurslars",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Egitmenlers_KurslarsKursId",
                table: "Egitmenlers",
                column: "KurslarsKursId");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinliklers_SalonlarsSalonId",
                table: "Etkinliklers",
                column: "SalonlarsSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurslars_SalonlarsSalonId",
                table: "Kurslars",
                column: "SalonlarsSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyelers_EgitmenlersEgitmenId",
                table: "Uyelers",
                column: "EgitmenlersEgitmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyelers_KurslarsKursId",
                table: "Uyelers",
                column: "KurslarsKursId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etkinliklers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Uyelers");

            migrationBuilder.DropTable(
                name: "Egitmenlers");

            migrationBuilder.DropTable(
                name: "Kurslars");

            migrationBuilder.DropTable(
                name: "Salonlars");
        }
    }
}
