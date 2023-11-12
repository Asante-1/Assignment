using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff615c1b-a063-4768-ab8c-f1d4d81d59a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffcef64a-da04-4fb9-ab2d-7375a81c7e76");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff615c1b-a063-4768-ab8c-f1d4d81d59a9", "b642d7e2-02aa-42ee-8d20-49a8d118988a", "Administrator", "ADMINISTRATOR" },
                    { "ffcef64a-da04-4fb9-ab2d-7375a81c7e76", "41c97d07-ce4d-4623-921d-96e64b526c31", "Member", "MEMBER" }
                });
        }
    }
}
