using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestZelfRelatie.Migrations
{
    public partial class GebouwLokaalOmschrijving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Omschrijving",
                table: "Lokaal",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Omschrijving",
                table: "Gebouwen",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Lokaal",
                newName: "Omschrijving");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Gebouwen",
                newName: "Omschrijving");
        }
    }
}
