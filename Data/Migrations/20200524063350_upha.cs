using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class upha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHangDetails",
                table: "DonHangDetails");

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "Mangas",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHangDetails",
                table: "DonHangDetails",
                columns: new[] { "DonHangId", "MangaId" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "56f459ce-9f4b-4f89-bfb6-c3d2af540491");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e3bdd79-cfee-45ad-8231-8c84b3dd66fa", "AQAAAAEAACcQAAAAEJiTCi/kKdK3Ux1YDsd/PJNG8ijj/Nd/mcON6yKM1zTl7wYHf8rdAkZ8DujsrS7MXA==" });

            migrationBuilder.UpdateData(
                table: "Mangas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Anhien",
                value: true);

            migrationBuilder.UpdateData(
                table: "Mangas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Anhien",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHangDetails",
                table: "DonHangDetails");

            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "Mangas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHangDetails",
                table: "DonHangDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9d3c416f-87be-43fa-ae6f-8323a91c50ed");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84004713-731e-4187-a6d3-94cf6e958dd3", "AQAAAAEAACcQAAAAEAYsJ/6YYEEBqNVMddNwIvCFjGnzPq7DsF20Lye88u1L7xjHWtFoSBZ3R1zh0DacvA==" });

            migrationBuilder.UpdateData(
                table: "Mangas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Anhien",
                value: true);

            migrationBuilder.UpdateData(
                table: "Mangas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Anhien",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonHangDetails_DonHangId",
                table: "DonHangDetails",
                column: "DonHangId");
        }
    }
}