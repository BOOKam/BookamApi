using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class Time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3460fa06-0578-4fba-939f-e2aee7808117");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e11123-154f-4440-99e1-feeeb368b7bc");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Routes");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "Bus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Bus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30d65d59-4372-4469-92ee-86a098ef0a0f", null, "Admin", "ADMIN" },
                    { "4dadfe36-0183-4f9e-9dbf-5e5d790a73f2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30d65d59-4372-4469-92ee-86a098ef0a0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dadfe36-0183-4f9e-9dbf-5e5d790a73f2");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Bus");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTime",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureTime",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3460fa06-0578-4fba-939f-e2aee7808117", null, "Admin", "ADMIN" },
                    { "a8e11123-154f-4440-99e1-feeeb368b7bc", null, "User", "USER" }
                });
        }
    }
}
