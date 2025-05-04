using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class Bookingcorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Booking",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2225f674-982e-41c0-82e4-9b6d312ed1d6", null, "User", "USER" },
                    { "2ef5c055-27ce-4b9b-b2ce-c6e49f68706d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BusId",
                table: "Booking",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RouteId",
                table: "Booking",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Bus_BusId",
                table: "Booking",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Routes_RouteId",
                table: "Booking",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Bus_BusId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Routes_RouteId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_BusId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_RouteId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserId",
                table: "Booking");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2225f674-982e-41c0-82e4-9b6d312ed1d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ef5c055-27ce-4b9b-b2ce-c6e49f68706d");

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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Booking",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
