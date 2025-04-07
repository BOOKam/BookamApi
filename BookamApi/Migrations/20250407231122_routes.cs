using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class routes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bf26c49-9c23-45dd-b271-760c029c6e0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d790aee9-3831-4c99-a13e-8acf29dac59b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "183b1060-3b37-4785-b218-8c02070fa216", null, "Admin", "ADMIN" },
                    { "2efe4fc0-5e3d-4fa8-92b9-cd524026536a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "183b1060-3b37-4785-b218-8c02070fa216");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2efe4fc0-5e3d-4fa8-92b9-cd524026536a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bf26c49-9c23-45dd-b271-760c029c6e0c", null, "Admin", "ADMIN" },
                    { "d790aee9-3831-4c99-a13e-8acf29dac59b", null, "User", "USER" }
                });
        }
    }
}
