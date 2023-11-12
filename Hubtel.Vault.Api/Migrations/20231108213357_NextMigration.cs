using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class NextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "274fae77-1aa8-4d01-a71d-198045d3ff5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc037db6-9fa4-4d6d-bb51-e964ec4a163d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "566bcfbd-c1d3-4ae8-a3f7-e4027454c2af", "e35df98c-cb58-4488-b37e-443675006db5", "Member", "MEMBER" },
                    { "8405927d-7e4a-4edd-aab3-2da3e2995d6c", "7066de67-77b2-43f6-ba33-450c68652d50", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "566bcfbd-c1d3-4ae8-a3f7-e4027454c2af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8405927d-7e4a-4edd-aab3-2da3e2995d6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "274fae77-1aa8-4d01-a71d-198045d3ff5a", "0ace8640-ca01-47a9-b224-71fc8c1ec944", "Member", "MEMBER" },
                    { "cc037db6-9fa4-4d6d-bb51-e964ec4a163d", "8f0fabc5-4482-456b-803e-5df00ab90baf", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
