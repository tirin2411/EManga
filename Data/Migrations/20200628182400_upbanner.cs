using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class upbanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "Banners",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Banners",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f1b73308-4553-43ff-a73c-3c900e7b0599");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "b3c5f242-6c24-4c31-93ac-86c36bd0d355", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAENyirvdpwCRqgekhT3TUj/nvrD3YurBCZiq1onS41BTnTD4aqfB4KbhJUnVk7NKtOQ==" });

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
            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Banners");

            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "180725b0-2411-44cc-990e-f96a1abb90f5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "0821c02b-bdf0-42eb-985b-43083db81732", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAECGonR5iyYZRSy2y4wIlE3itu5Mdd0o4K/mgkbYXrT/tClzcW5mu8WDhtJlGCehM6w==" });

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
