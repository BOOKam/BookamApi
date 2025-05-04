using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class AvailableSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f748506-86d3-4f64-867e-6f86d9e50d36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86340dc8-037f-4762-8234-04cf66796d08");

            migrationBuilder.AddColumn<List<int>>(
                name: "AvailableSeats",
                table: "Bus",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<List<int>>(
                name: "BookedSeats",
                table: "Bus",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f60ab3e-ada2-4c2a-ab43-ca08457e1313", null, "Admin", "ADMIN" },
                    { "d7eb4b88-fb98-47a8-92be-fc2e90b9d322", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f60ab3e-ada2-4c2a-ab43-ca08457e1313");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7eb4b88-fb98-47a8-92be-fc2e90b9d322");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Bus");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f748506-86d3-4f64-867e-6f86d9e50d36", null, "Admin", "ADMIN" },
                    { "86340dc8-037f-4762-8234-04cf66796d08", null, "User", "USER" }
                });
        }
    }
}
