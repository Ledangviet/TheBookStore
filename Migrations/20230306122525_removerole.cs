using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookStore.Migrations
{
    public partial class removerole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "152ccde6-1188-41c6-91de-ad6dc7449b05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c4e91d3-d362-423a-93a9-f460c00e1cd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80c43274-6462-4a33-a889-317d74263bf0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5fdeee8-e9a6-4086-ac37-c876cdf44658");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "152ccde6-1188-41c6-91de-ad6dc7449b05", "2", "User", "User" },
                    { "3c4e91d3-d362-423a-93a9-f460c00e1cd2", "3", "Dev", "Dev" },
                    { "80c43274-6462-4a33-a889-317d74263bf0", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a5fdeee8-e9a6-4086-ac37-c876cdf44658", 0, "5fcd0853-5663-4b87-b267-84e870bb4bcf", "Admin@gmail.com", false, false, null, "Administrator", null, null, null, null, false, "096d9e9f-de68-4966-af0b-26e7d6b7ba2f", false, "Administrator" });
        }
    }
}
