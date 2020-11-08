using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class SeañadieronlatlngenEntradas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatOrigen",
                table: "Entradas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LngOrigen",
                table: "Entradas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatOrigen",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "LngOrigen",
                table: "Entradas");
        }
    }
}
