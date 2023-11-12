using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class MadeChangesToModelss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ownwer",
                table: "wallet",
                newName: "owner");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7097d1cb-f15b-43aa-85df-1340494e43e8", "0a34c12a-48e2-4def-a963-715597825354", "Administrator", "ADMINISTRATOR" },
                    { "89771a2a-78d0-4665-ab9b-947e4ab12cd6", "1f55e2b3-0a6d-4b06-8d35-8c74447f97a9", "Member", "MEMBER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7097d1cb-f15b-43aa-85df-1340494e43e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89771a2a-78d0-4665-ab9b-947e4ab12cd6");

            migrationBuilder.RenameColumn(
                name: "owner",
                table: "wallet",
                newName: "ownwer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6500f371-05a9-4627-87c8-d3603f73e587", "a2c40fe2-b126-4cf3-a481-728b3b1dc286", "Member", "MEMBER" },
                    { "8ef28ec4-ed42-4fcd-bfd4-b63194b6aa72", "8959079f-ec88-42fb-ac92-8e936e3ccab6", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
