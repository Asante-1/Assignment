using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hubtel.Vault.Api.Migrations
{
    public partial class WalletTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35fcf648-af1a-4e41-93c6-961403549cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ad4ce6c-1a73-4ed8-8900-d5a03efe094c");

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Owner = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff615c1b-a063-4768-ab8c-f1d4d81d59a9", "b642d7e2-02aa-42ee-8d20-49a8d118988a", "Administrator", "ADMINISTRATOR" },
                    { "ffcef64a-da04-4fb9-ab2d-7375a81c7e76", "41c97d07-ce4d-4623-921d-96e64b526c31", "Member", "MEMBER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff615c1b-a063-4768-ab8c-f1d4d81d59a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffcef64a-da04-4fb9-ab2d-7375a81c7e76");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35fcf648-af1a-4e41-93c6-961403549cee", "beabd1fe-0aa8-42b2-8c46-046084399e97", "Member", "MEMBER" },
                    { "5ad4ce6c-1a73-4ed8-8900-d5a03efe094c", "898d8cd6-93bd-465e-a852-652b70bdf624", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
