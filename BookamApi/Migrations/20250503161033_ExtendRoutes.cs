using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookamApi.Migrations
{
    /// <inheritdoc />
    public partial class ExtendRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4d2d70-1e07-4e60-aca7-daa0d21e3130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa1b77c1-9ed4-4e99-b3fc-5baf86119b69");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Routes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distance",
                table: "Routes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Routes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Routes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84049df1-eca8-4bce-9830-e18894b64249", null, "Admin", "ADMIN" },
                    { "c1fa5237-c4bb-4345-bf27-4df531ca1ce0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84049df1-eca8-4bce-9830-e18894b64249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1fa5237-c4bb-4345-bf27-4df531ca1ce0");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Routes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d4d2d70-1e07-4e60-aca7-daa0d21e3130", null, "Admin", "ADMIN" },
                    { "fa1b77c1-9ed4-4e99-b3fc-5baf86119b69", null, "User", "USER" }
                });
        }
    }
}
