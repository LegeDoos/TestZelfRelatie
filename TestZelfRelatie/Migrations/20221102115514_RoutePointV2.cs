using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestZelfRelatie.Migrations
{
    public partial class RoutePointV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoutePointsV2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePointsV2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutePointRelationV2",
                columns: table => new
                {
                    RoutePointRelationV2Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    RoutePointV2FromId = table.Column<int>(type: "int", nullable: false),
                    RoutePointV2ToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePointRelationV2", x => x.RoutePointRelationV2Id);
                    table.ForeignKey(
                        name: "FK_RoutePointRelationV2_RoutePointsV2_RoutePointV2FromId",
                        column: x => x.RoutePointV2FromId,
                        principalTable: "RoutePointsV2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoutePointRelationV2_RoutePointsV2_RoutePointV2ToId",
                        column: x => x.RoutePointV2ToId,
                        principalTable: "RoutePointsV2",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutePointRelationV2_RoutePointV2FromId",
                table: "RoutePointRelationV2",
                column: "RoutePointV2FromId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePointRelationV2_RoutePointV2ToId",
                table: "RoutePointRelationV2",
                column: "RoutePointV2ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutePointRelationV2");

            migrationBuilder.DropTable(
                name: "RoutePointsV2");
        }
    }
}
