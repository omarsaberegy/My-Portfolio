using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("a5bbabb5-ba92-4152-be2b-30f80b72d89c"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Owners",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "Avatar", "FullName", "JobTitle" },
                values: new object[] { new Guid("dcfe7f19-7af4-46b7-847d-056957daeca3"), null, "avatar.jpg", "Omar Saber", "Web Developer" });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressId",
                table: "Owners",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Address_AddressId",
                table: "Owners",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Address_AddressId",
                table: "Owners");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Owners_AddressId",
                table: "Owners");

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("dcfe7f19-7af4-46b7-847d-056957daeca3"));

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Owners");

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Avatar", "FullName", "JobTitle" },
                values: new object[] { new Guid("a5bbabb5-ba92-4152-be2b-30f80b72d89c"), "avatar.jpg", "Omar Saber", "Web Developer" });
        }
    }
}
