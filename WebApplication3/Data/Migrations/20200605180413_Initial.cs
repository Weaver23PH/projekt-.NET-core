using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bagnety",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bagnety", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    UpperCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategorie_Kategorie_UpperCategoryId",
                        column: x => x.UpperCategoryId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obiektywy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producent = table.Column<string>(maxLength: 50, nullable: false),
                    KrajPochodzenia = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 100, nullable: true),
                    RokProdukcji = table.Column<DateTime>(nullable: false),
                    Waga = table.Column<int>(nullable: false),
                    Staloogniskowy = table.Column<bool>(nullable: false),
                    OgniskowaMin = table.Column<int>(nullable: false),
                    OgniskowaMax = table.Column<int>(nullable: false),
                    PrzesłonaMax = table.Column<int>(nullable: false),
                    PrzesłonaMin = table.Column<int>(nullable: false),
                    BagnetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obiektywy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obiektywy_Bagnety_BagnetId",
                        column: x => x.BagnetId,
                        principalTable: "Bagnety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aparaty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producent = table.Column<string>(maxLength: 50, nullable: false),
                    KrajPochodzenia = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 100, nullable: true),
                    RokProdukcji = table.Column<DateTime>(nullable: false),
                    Waga = table.Column<int>(nullable: false),
                    Wycofany = table.Column<bool>(nullable: false),
                    BagnetId = table.Column<int>(nullable: false),
                    AparatKategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aparaty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aparaty_Kategorie_AparatKategoriaId",
                        column: x => x.AparatKategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aparaty_Bagnety_BagnetId",
                        column: x => x.BagnetId,
                        principalTable: "Bagnety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aparaty_AparatKategoriaId",
                table: "Aparaty",
                column: "AparatKategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aparaty_BagnetId",
                table: "Aparaty",
                column: "BagnetId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorie_UpperCategoryId",
                table: "Kategorie",
                column: "UpperCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Obiektywy_BagnetId",
                table: "Obiektywy",
                column: "BagnetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aparaty");

            migrationBuilder.DropTable(
                name: "Obiektywy");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Bagnety");
        }
    }
}
