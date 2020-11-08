using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class Seañadieroncategoriasdearchivo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos_CategoriaArchivos_IdCategoriaArchivo",
                table: "Archivos");

            migrationBuilder.DropIndex(
                name: "IX_Archivos_IdCategoriaArchivo",
                table: "Archivos");

            migrationBuilder.DropColumn(
                name: "IdCategoriaArchivo",
                table: "Archivos");

            migrationBuilder.AddColumn<string>(
                name: "UrlArchivo",
                table: "Archivos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivoCategoriaArchivos",
                columns: table => new
                {
                    IdArchivoCategoriaArchivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArchivo = table.Column<int>(nullable: false),
                    IdCategoriaArchivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoCategoriaArchivos", x => x.IdArchivoCategoriaArchivo);
                    table.ForeignKey(
                        name: "FK_ArchivoCategoriaArchivos_Archivos_IdArchivo",
                        column: x => x.IdArchivo,
                        principalTable: "Archivos",
                        principalColumn: "IdArchivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivoCategoriaArchivos_CategoriaArchivos_IdCategoriaArchivo",
                        column: x => x.IdCategoriaArchivo,
                        principalTable: "CategoriaArchivos",
                        principalColumn: "IdCategoriaArchivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoCategoriaArchivos_IdArchivo",
                table: "ArchivoCategoriaArchivos",
                column: "IdArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoCategoriaArchivos_IdCategoriaArchivo",
                table: "ArchivoCategoriaArchivos",
                column: "IdCategoriaArchivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivoCategoriaArchivos");

            migrationBuilder.DropColumn(
                name: "UrlArchivo",
                table: "Archivos");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaArchivo",
                table: "Archivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_IdCategoriaArchivo",
                table: "Archivos",
                column: "IdCategoriaArchivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos_CategoriaArchivos_IdCategoriaArchivo",
                table: "Archivos",
                column: "IdCategoriaArchivo",
                principalTable: "CategoriaArchivos",
                principalColumn: "IdCategoriaArchivo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
