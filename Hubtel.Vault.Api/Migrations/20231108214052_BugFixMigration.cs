using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class BugFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "566bcfbd-c1d3-4ae8-a3f7-e4027454c2af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8405927d-7e4a-4edd-aab3-2da3e2995d6c");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a86ba73-2dd2-4a41-9ae8-dff14840d125", "9545e5ff-d823-47ab-a3e1-6c636c31dc2c", "Member", "MEMBER" },
                    { "ba12cc0c-8975-4a2e-bc48-67ec5e8a4bc0", "9edfe7ad-4295-46b3-ae53-eb5a145a5455", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a86ba73-2dd2-4a41-9ae8-dff14840d125");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba12cc0c-8975-4a2e-bc48-67ec5e8a4bc0");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "566bcfbd-c1d3-4ae8-a3f7-e4027454c2af", "e35df98c-cb58-4488-b37e-443675006db5", "Member", "MEMBER" },
                    { "8405927d-7e4a-4edd-aab3-2da3e2995d6c", "7066de67-77b2-43f6-ba33-450c68652d50", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
