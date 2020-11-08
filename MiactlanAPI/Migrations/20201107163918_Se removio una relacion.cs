using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class Seremoviounarelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Categorias_CategoriaIdCategoria",
                table: "Entradas");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_CategoriaIdCategoria",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Entradas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Entradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_CategoriaIdCategoria",
                table: "Entradas",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Categorias_CategoriaIdCategoria",
                table: "Entradas",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
