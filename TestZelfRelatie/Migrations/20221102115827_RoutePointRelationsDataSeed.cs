using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestZelfRelatie.Migrations
{
    public partial class RoutePointRelationsDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoutePointsV2",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Routepoint a" });

            migrationBuilder.InsertData(
                table: "RoutePointsV2",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Routepoint b" });

            migrationBuilder.InsertData(
                table: "RoutePointsV2",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Routepoint c" });

            migrationBuilder.InsertData(
                table: "RoutePointRelationV2",
                columns: new[] { "RoutePointRelationV2Id", "Description", "Distance", "RoutePointV2FromId", "RoutePointV2ToId" },
                values: new object[,]
                {
                    { 1, "Van a naar b", 10, 1, 2 },
                    { 2, "Van b naar a", 10, 2, 1 },
                    { 3, "Van a naar c", 20, 1, 3 },
                    { 4, "Van c naar a", 20, 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoutePointRelationV2",
                keyColumn: "RoutePointRelationV2Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoutePointRelationV2",
                keyColumn: "RoutePointRelationV2Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoutePointRelationV2",
                keyColumn: "RoutePointRelationV2Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoutePointRelationV2",
                keyColumn: "RoutePointRelationV2Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoutePointsV2",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoutePointsV2",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoutePointsV2",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
