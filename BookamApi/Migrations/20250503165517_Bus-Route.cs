using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class BusRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "84049df1-eca8-4bce-9830-e18894b64249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1fa5237-c4bb-4345-bf27-4df531ca1ce0");

            migrationBuilder.DropColumn(
                name: "RoutesRouteId",
                table: "Bus");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39e05f1e-567d-4020-8ac7-8b51cf06b966", null, "Admin", "ADMIN" },
                    { "68ba180e-709d-4bfd-894a-012710b34ef4", null, "User", "USER" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "39e05f1e-567d-4020-8ac7-8b51cf06b966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ba180e-709d-4bfd-894a-012710b34ef4");

            migrationBuilder.AddColumn<int>(
                name: "RoutesRouteId",
                table: "Bus",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84049df1-eca8-4bce-9830-e18894b64249", null, "Admin", "ADMIN" },
                    { "c1fa5237-c4bb-4345-bf27-4df531ca1ce0", null, "User", "USER" }
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
    }
}
