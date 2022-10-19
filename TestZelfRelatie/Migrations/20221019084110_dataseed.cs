using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestZelfRelatie.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoutePoints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "a" },
                    { 2, "b" },
                    { 3, "c" },
                    { 4, "d" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
