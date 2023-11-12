using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class RoleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "274fae77-1aa8-4d01-a71d-198045d3ff5a", "0ace8640-ca01-47a9-b224-71fc8c1ec944", "Member", "MEMBER" },
                    { "cc037db6-9fa4-4d6d-bb51-e964ec4a163d", "8f0fabc5-4482-456b-803e-5df00ab90baf", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "274fae77-1aa8-4d01-a71d-198045d3ff5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc037db6-9fa4-4d6d-bb51-e964ec4a163d");
        }
    }
}
