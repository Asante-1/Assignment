using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class NewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "939f1c5b-b7e5-47f7-856e-e9b7c63670ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcdb0fdc-a5ef-4282-9521-2ab655b82896");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AccountScheme",
                table: "Wallet",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49beb09f-fa07-4abe-8160-77c80ebc2c03", "bc0fb003-084f-4aaf-98aa-1efcc73a1de7", "Member", "MEMBER" },
                    { "6b91a66a-2ff5-4eb2-b867-82bfb3017515", "fc1b8586-7630-430c-bdfc-286a62f6b0ac", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49beb09f-fa07-4abe-8160-77c80ebc2c03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b91a66a-2ff5-4eb2-b867-82bfb3017515");

            migrationBuilder.DropColumn(
                name: "AccountScheme",
                table: "Wallet");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "939f1c5b-b7e5-47f7-856e-e9b7c63670ae", "9bac8cf6-2051-424c-8dee-a06397aba85f", "Member", "MEMBER" },
                    { "dcdb0fdc-a5ef-4282-9521-2ab655b82896", "49a7df4a-a8c0-4c66-9d00-aff685ca87e1", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
