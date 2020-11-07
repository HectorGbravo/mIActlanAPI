using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class SeagregaronLikesComentariosyEntradasCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    IdComentario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntrada = table.Column<int>(nullable: false),
                    EntradaIdEntrada = table.Column<int>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Entradas_EntradaIdEntrada",
                        column: x => x.EntradaIdEntrada,
                        principalTable: "Entradas",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntradaCategorias",
                columns: table => new
                {
                    IdEntradaCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntrada = table.Column<int>(nullable: false),
                    EntradaIdEntrada = table.Column<int>(nullable: true),
                    IdCategoria = table.Column<int>(nullable: false),
                    CategoriaIdCategoria = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaCategorias", x => x.IdEntradaCategoria);
                    table.ForeignKey(
                        name: "FK_EntradaCategorias_Categorias_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaCategorias_Entradas_EntradaIdEntrada",
                        column: x => x.EntradaIdEntrada,
                        principalTable: "Entradas",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    IdLike = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true),
                    IdEntrada = table.Column<int>(nullable: false),
                    EntradaIdEntrada = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.IdLike);
                    table.ForeignKey(
                        name: "FK_Likes_Entradas_EntradaIdEntrada",
                        column: x => x.EntradaIdEntrada,
                        principalTable: "Entradas",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EntradaIdEntrada",
                table: "Comentarios",
                column: "EntradaIdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaCategorias_CategoriaIdCategoria",
                table: "EntradaCategorias",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaCategorias_EntradaIdEntrada",
                table: "EntradaCategorias",
                column: "EntradaIdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_EntradaIdEntrada",
                table: "Likes",
                column: "EntradaIdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UsuarioId",
                table: "Likes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "EntradaCategorias");

            migrationBuilder.DropTable(
                name: "Likes");
        }
    }
}
