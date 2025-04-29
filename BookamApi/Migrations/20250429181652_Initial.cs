using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60b4fbc0-d212-4f5f-8c7e-e32c4d39e566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c70bf521-721d-4fba-b1a2-81b48150d3e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2059ed78-9a04-4971-b5ce-00bebc2ea924", null, "User", "USER" },
                    { "e14a8b9f-3932-400c-87da-8c6ee3d2f66f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2059ed78-9a04-4971-b5ce-00bebc2ea924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e14a8b9f-3932-400c-87da-8c6ee3d2f66f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60b4fbc0-d212-4f5f-8c7e-e32c4d39e566", null, "User", "USER" },
                    { "c70bf521-721d-4fba-b1a2-81b48150d3e9", null, "Admin", "ADMIN" }
                });
        }
    }
}
