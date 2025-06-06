using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00ba78fb-2b8c-437c-89fb-94b02da2425c", "b4941a8b-dcbe-42ee-86b4-22406d304242", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ca2c1da-a246-4d82-a6b9-3ae97488268e", "e3c9b61c-f030-45d5-9738-90a01d01d52d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e9cb8ae-ca1f-4542-a88d-502eed702657", "a1b1721b-1f5d-4ad2-8641-93289014e9e7", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00ba78fb-2b8c-437c-89fb-94b02da2425c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca2c1da-a246-4d82-a6b9-3ae97488268e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e9cb8ae-ca1f-4542-a88d-502eed702657");
        }
    }
}
