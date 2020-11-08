using Microsoft.EntityFrameworkCore.Migrations;

namespace MiactlanAPI.Migrations
{
    public partial class Seañadieronlatlng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatCentral",
                table: "Entidades",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LngCentral",
                table: "Entidades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatCentral",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "LngCentral",
                table: "Entidades");
        }
    }
}
