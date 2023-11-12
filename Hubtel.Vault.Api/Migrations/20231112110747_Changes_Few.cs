using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class Changes_Few : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0546094-391c-4ec5-b75c-d1d9ddc24f85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2dbaa7e-7e8b-4186-b42c-8d5a4cdb4afa");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "wallet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wallet",
                table: "wallet",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d3d42a4-985e-41c4-9e4a-3bd5b14725fe", "47191075-e0b6-491e-875a-5ca64a1a77f5", "Administrator", "ADMINISTRATOR" },
                    { "6adb58f4-4927-4b8c-971c-89bde7cd811f", "14638cd5-5537-4266-8d1c-2b568f257e2b", "Member", "MEMBER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_wallet",
                table: "wallet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d3d42a4-985e-41c4-9e4a-3bd5b14725fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6adb58f4-4927-4b8c-971c-89bde7cd811f");

            migrationBuilder.RenameTable(
                name: "wallet",
                newName: "Wallet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e0546094-391c-4ec5-b75c-d1d9ddc24f85", "b6bd11c9-1744-4ad8-8bbb-bbce8673d18e", "Member", "MEMBER" },
                    { "e2dbaa7e-7e8b-4186-b42c-8d5a4cdb4afa", "563f7ccf-63f2-4c75-9a4e-6f513c814922", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
