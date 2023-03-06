using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookStore.Migrations
{
    public partial class role1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89dfe838-2d42-4446-b5dc-e6df94a70253", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c4b6be2-e51c-4820-a54e-ed0e540754be", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89dfe838-2d42-4446-b5dc-e6df94a70253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c4b6be2-e51c-4820-a54e-ed0e540754be");
        }
    }
}
