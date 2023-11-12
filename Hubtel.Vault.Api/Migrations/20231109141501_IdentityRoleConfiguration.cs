using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class IdentityRoleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a86ba73-2dd2-4a41-9ae8-dff14840d125");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba12cc0c-8975-4a2e-bc48-67ec5e8a4bc0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35fcf648-af1a-4e41-93c6-961403549cee", "beabd1fe-0aa8-42b2-8c46-046084399e97", "Member", "MEMBER" },
                    { "5ad4ce6c-1a73-4ed8-8900-d5a03efe094c", "898d8cd6-93bd-465e-a852-652b70bdf624", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35fcf648-af1a-4e41-93c6-961403549cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ad4ce6c-1a73-4ed8-8900-d5a03efe094c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a86ba73-2dd2-4a41-9ae8-dff14840d125", "9545e5ff-d823-47ab-a3e1-6c636c31dc2c", "Member", "MEMBER" },
                    { "ba12cc0c-8975-4a2e-bc48-67ec5e8a4bc0", "9edfe7ad-4295-46b3-ae53-eb5a145a5455", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
