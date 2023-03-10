using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookStore.Migrations
{
    public partial class guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eb4e0c4-0b92-4ded-b4a7-667c7e03affc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53f6091e-12bb-4d4b-b008-fc8ed83236d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "677240f0-ecc5-4094-ac53-a5d1ddeb1a17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68a0ace6-a6fa-46eb-aa22-2538d9aab6ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d806b6-548a-4368-ab26-069e2c5bbbbc", "2", "User", "User" },
                    { "5dc6c346-e218-4571-926f-61f47d0ad560", "3", "Dev", "Dev" },
                    { "75e0cb46-e4e3-4010-9e1c-42dab96704fb", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5ff345d4-9d0b-477f-a77a-ce773c26b987", 0, "56e57021-04e7-4f86-986e-245095f739d1", "Admin@gmail.com", false, false, null, "Administrator", null, null, null, null, false, "be1f7d1e-1c82-49a4-956d-b7a8be657204", false, "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d806b6-548a-4368-ab26-069e2c5bbbbc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dc6c346-e218-4571-926f-61f47d0ad560");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75e0cb46-e4e3-4010-9e1c-42dab96704fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ff345d4-9d0b-477f-a77a-ce773c26b987");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2eb4e0c4-0b92-4ded-b4a7-667c7e03affc", "2", "User", "User" },
                    { "53f6091e-12bb-4d4b-b008-fc8ed83236d3", "3", "Dev", "Dev" },
                    { "677240f0-ecc5-4094-ac53-a5d1ddeb1a17", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "68a0ace6-a6fa-46eb-aa22-2538d9aab6ba", 0, "eecd7f8b-7ae9-47d9-8eee-84ac30333ea1", "Admin@gmail.com", false, false, null, "Administrator", null, null, null, null, false, "14e5385b-b877-4d32-b1f6-badce56bfd9a", false, "Administrator" });
        }
    }
}
