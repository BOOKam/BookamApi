using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class Booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PaymentStatus",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Routes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Bus",
                type: "integer",
                nullable: true);
            
            migrationBuilder.Sql(
                @"ALTER TABLE ""Booking"" 
                ALTER COLUMN ""SeatNumber"" 
                TYPE integer 
                USING ""SeatNumber""::integer;");

            migrationBuilder.AlterColumn<int>(
                name: "SeatNumber",
                table: "Booking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Booking",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "CheckedIn",
                table: "Booking",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Booking",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20748680-1aa9-40fb-9a65-32dac43f3fb7", null, "Admin", "ADMIN" },
                    { "4300adb6-c1cb-4cd6-98d2-7325026f28b6", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_BookingId",
                table: "Routes",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_BookingId",
                table: "Bus",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Booking_BookingId",
                table: "Bus",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Booking_BookingId",
                table: "Routes",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Booking_BookingId",
                table: "Bus");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Booking_BookingId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_BookingId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Bus_BookingId",
                table: "Bus");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20748680-1aa9-40fb-9a65-32dac43f3fb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4300adb6-c1cb-4cd6-98d2-7325026f28b6");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "CheckedIn",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SeatNumber",
                table: "Booking",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatedAt",
                table: "Booking",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Booking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f60ab3e-ada2-4c2a-ab43-ca08457e1313", null, "Admin", "ADMIN" },
                    { "d7eb4b88-fb98-47a8-92be-fc2e90b9d322", null, "User", "USER" }
                });
        }
    }
}
