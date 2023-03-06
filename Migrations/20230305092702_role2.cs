using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookStore.Migrations
{
    public partial class role2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89dfe838-2d42-4446-b5dc-e6df94a70253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c4b6be2-e51c-4820-a54e-ed0e540754be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "247d7beb-1ab4-4e95-b39c-36ea7ffe00d6", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9665ab21-d6e4-4c8a-993c-a648aa01291a", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "247d7beb-1ab4-4e95-b39c-36ea7ffe00d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9665ab21-d6e4-4c8a-993c-a648aa01291a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89dfe838-2d42-4446-b5dc-e6df94a70253", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c4b6be2-e51c-4820-a54e-ed0e540754be", "2", "User", "User" });
        }
    }
}
