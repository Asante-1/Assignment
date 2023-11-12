using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class MadeChangesToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d3d42a4-985e-41c4-9e4a-3bd5b14725fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6adb58f4-4927-4b8c-971c-89bde7cd811f");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "wallet");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "wallet",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "wallet",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "wallet",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "wallet",
                newName: "ownwer");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "wallet",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AccountScheme",
                table: "wallet",
                newName: "account_scheme");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "wallet",
                newName: "account_number");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6500f371-05a9-4627-87c8-d3603f73e587", "a2c40fe2-b126-4cf3-a481-728b3b1dc286", "Member", "MEMBER" },
                    { "8ef28ec4-ed42-4fcd-bfd4-b63194b6aa72", "8959079f-ec88-42fb-ac92-8e936e3ccab6", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6500f371-05a9-4627-87c8-d3603f73e587");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ef28ec4-ed42-4fcd-bfd4-b63194b6aa72");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "wallet",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "wallet",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "wallet",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ownwer",
                table: "wallet",
                newName: "Owner");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "wallet",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "account_scheme",
                table: "wallet",
                newName: "AccountScheme");

            migrationBuilder.RenameColumn(
                name: "account_number",
                table: "wallet",
                newName: "AccountNumber");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "wallet",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d3d42a4-985e-41c4-9e4a-3bd5b14725fe", "47191075-e0b6-491e-875a-5ca64a1a77f5", "Administrator", "ADMINISTRATOR" },
                    { "6adb58f4-4927-4b8c-971c-89bde7cd811f", "14638cd5-5537-4266-8d1c-2b568f257e2b", "Member", "MEMBER" }
                });
        }
    }
}
