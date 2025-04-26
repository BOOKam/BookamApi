using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class ReAddWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "388ef6aa-ae85-4050-a569-d0c7a4bd4b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3074216-3be5-408b-912c-58e9146886c2");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Booking",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60b4fbc0-d212-4f5f-8c7e-e32c4d39e566", null, "User", "USER" },
                    { "c70bf521-721d-4fba-b1a2-81b48150d3e9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60b4fbc0-d212-4f5f-8c7e-e32c4d39e566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c70bf521-721d-4fba-b1a2-81b48150d3e9");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Booking",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "388ef6aa-ae85-4050-a569-d0c7a4bd4b0e", null, "Admin", "ADMIN" },
                    { "f3074216-3be5-408b-912c-58e9146886c2", null, "User", "USER" }
                });
        }
    }
}
