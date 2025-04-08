using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class someChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Routes_RouteId",
                table: "Bus");

            migrationBuilder.DropIndex(
                name: "IX_Bus_RouteId",
                table: "Bus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "263bdfb3-12b4-4b14-bf42-88ec097dad43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d27588af-8054-4e6d-98a1-47f2728a34ee");

            migrationBuilder.AddColumn<int>(
                name: "RoutesRouteId",
                table: "Bus",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47d11f06-37ec-429d-9092-db7d6973cb62", null, "User", "USER" },
                    { "de962236-72e8-4077-826d-da693ccaf929", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_RoutesRouteId",
                table: "Bus",
                column: "RoutesRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Routes_RoutesRouteId",
                table: "Bus",
                column: "RoutesRouteId",
                principalTable: "Routes",
                principalColumn: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Routes_RoutesRouteId",
                table: "Bus");

            migrationBuilder.DropIndex(
                name: "IX_Bus_RoutesRouteId",
                table: "Bus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47d11f06-37ec-429d-9092-db7d6973cb62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de962236-72e8-4077-826d-da693ccaf929");

            migrationBuilder.DropColumn(
                name: "RoutesRouteId",
                table: "Bus");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "263bdfb3-12b4-4b14-bf42-88ec097dad43", null, "User", "USER" },
                    { "d27588af-8054-4e6d-98a1-47f2728a34ee", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_RouteId",
                table: "Bus",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Routes_RouteId",
                table: "Bus",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
