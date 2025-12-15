using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SesjeTreningowe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CzasRozpoczecia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CzasZakonczenia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UzytkownikId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesjeTreningowe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypyCwiczen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyCwiczen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cwiczenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LiczbaSerii = table.Column<int>(type: "INTEGER", nullable: false),
                    Obciazenie = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    TypCwiczeniaId = table.Column<int>(type: "INTEGER", nullable: false),
                    SesjaTreningowaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cwiczenia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cwiczenia_SesjeTreningowe_SesjaTreningowaId",
                        column: x => x.SesjaTreningowaId,
                        principalTable: "SesjeTreningowe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cwiczenia_TypyCwiczen_TypCwiczeniaId",
                        column: x => x.TypCwiczeniaId,
                        principalTable: "TypyCwiczen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cwiczenia_SesjaTreningowaId",
                table: "Cwiczenia",
                column: "SesjaTreningowaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cwiczenia_TypCwiczeniaId",
                table: "Cwiczenia",
                column: "TypCwiczeniaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cwiczenia");

            migrationBuilder.DropTable(
                name: "SesjeTreningowe");

            migrationBuilder.DropTable(
                name: "TypyCwiczen");
        }
    }
}
