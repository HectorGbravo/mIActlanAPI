using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class SeagregaronEntradas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    IdEntrada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    IdCategoria = table.Column<long>(nullable: false),
                    CategoriaIdCategoria = table.Column<long>(nullable: true),
                    IdEntidad = table.Column<int>(nullable: false),
                    EntidadIdEntidad = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.IdEntrada);
                    table.ForeignKey(
                        name: "FK_Entradas_Categorias_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entradas_Entidades_EntidadIdEntidad",
                        column: x => x.EntidadIdEntidad,
                        principalTable: "Entidades",
                        principalColumn: "IdEntidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_CategoriaIdCategoria",
                table: "Entradas",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_EntidadIdEntidad",
                table: "Entradas",
                column: "EntidadIdEntidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entradas");
        }
    }
}
