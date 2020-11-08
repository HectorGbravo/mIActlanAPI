using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class Seañadieroncategoriasdearchivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaArchivos",
                columns: table => new
                {
                    IdCategoriaArchivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaTagId = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaArchivos", x => x.IdCategoriaArchivo);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    IdArchivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntrada = table.Column<int>(nullable: false),
                    IdCategoriaArchivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.IdArchivo);
                    table.ForeignKey(
                        name: "FK_Archivos_CategoriaArchivos_IdCategoriaArchivo",
                        column: x => x.IdCategoriaArchivo,
                        principalTable: "CategoriaArchivos",
                        principalColumn: "IdCategoriaArchivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Archivos_Entradas_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "Entradas",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_IdCategoriaArchivo",
                table: "Archivos",
                column: "IdCategoriaArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_IdEntrada",
                table: "Archivos",
                column: "IdEntrada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "CategoriaArchivos");
        }
    }
}
