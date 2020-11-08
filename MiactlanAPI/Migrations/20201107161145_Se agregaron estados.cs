using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class Seagregaronestados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "Entidades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.IdEstado);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_IdEstado",
                table: "Entidades",
                column: "IdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidades_Estado_IdEstado",
                table: "Entidades",
                column: "IdEstado",
                principalTable: "Estado",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidades_Estado_IdEstado",
                table: "Entidades");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Entidades_IdEstado",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "Entidades");
        }
    }
}
