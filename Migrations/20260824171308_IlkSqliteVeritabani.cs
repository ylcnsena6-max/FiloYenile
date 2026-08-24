using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiloYenile.Migrations
{
    /// <inheritdoc />
    public partial class IlkSqliteVeritabani : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Plaka = table.Column<string>(type: "TEXT", nullable: false),
                    Marka = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    ModelYili = table.Column<int>(type: "INTEGER", nullable: false),
                    Kilometre = table.Column<int>(type: "INTEGER", nullable: false),
                    YakitTuru = table.Column<string>(type: "TEXT", nullable: false),
                    YillikBakimMaliyeti = table.Column<decimal>(type: "TEXT", nullable: false),
                    YillikYakitMaliyeti = table.Column<decimal>(type: "TEXT", nullable: false),
                    ArizaSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    GuncelDeger = table.Column<decimal>(type: "TEXT", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AktifMi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Araclar");
        }
    }
}
