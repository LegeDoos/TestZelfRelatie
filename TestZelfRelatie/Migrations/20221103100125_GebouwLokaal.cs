using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestZelfRelatie.Migrations
{
    public partial class GebouwLokaal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebouwen",
                columns: table => new
                {
                    GebouwId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebouwen", x => x.GebouwId);
                });

            migrationBuilder.CreateTable(
                name: "Lokaal",
                columns: table => new
                {
                    LokaalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GebouwId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokaal", x => x.LokaalId);
                    table.ForeignKey(
                        name: "FK_Lokaal_Gebouwen_GebouwId",
                        column: x => x.GebouwId,
                        principalTable: "Gebouwen",
                        principalColumn: "GebouwId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokaal_GebouwId",
                table: "Lokaal",
                column: "GebouwId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokaal");

            migrationBuilder.DropTable(
                name: "Gebouwen");
        }
    }
}
