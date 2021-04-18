using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class zzz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHangHtrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHangHistories",
                table: "DonHangHistories");

            migrationBuilder.DropColumn(
                name: "id",
                table: "DonHangHistories");

            migrationBuilder.AddColumn<int>(
                name: "DonHangDetailId",
                table: "DonHangHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHangHistories",
                table: "DonHangHistories",
                column: "DonHangDetailId");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d14a6ca5-9592-4d8e-a94b-d78bce62ede2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f083d782-e966-46a1-a38a-eea0f0fd2f88", "AQAAAAEAACcQAAAAELGiOszBDevdimbo2BwFEdRW69f4X6U9jqyTXJbvDVYx0h27gQKUzlDX/TwzFaXAVg==" });

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
    }
}