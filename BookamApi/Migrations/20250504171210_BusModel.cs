using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class BusModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39e05f1e-567d-4020-8ac7-8b51cf06b966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ba180e-709d-4bfd-894a-012710b34ef4");

            migrationBuilder.AddColumn<string>(
                name: "BusModel",
                table: "Bus",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SeatsRemaining",
                table: "Bus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f748506-86d3-4f64-867e-6f86d9e50d36", null, "Admin", "ADMIN" },
                    { "86340dc8-037f-4762-8234-04cf66796d08", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f748506-86d3-4f64-867e-6f86d9e50d36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86340dc8-037f-4762-8234-04cf66796d08");

            migrationBuilder.DropColumn(
                name: "BusModel",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "SeatsRemaining",
                table: "Bus");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39e05f1e-567d-4020-8ac7-8b51cf06b966", null, "Admin", "ADMIN" },
                    { "68ba180e-709d-4bfd-894a-012710b34ef4", null, "User", "USER" }
                });
        }
    }
}
