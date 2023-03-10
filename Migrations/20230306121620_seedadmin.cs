using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookStore.Migrations
{
    public partial class seedadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "247d7beb-1ab4-4e95-b39c-36ea7ffe00d6", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9665ab21-d6e4-4c8a-993c-a648aa01291a", "2", "User", "User" });
        }
    }
}
