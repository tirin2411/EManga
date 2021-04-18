using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "TinTucs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Theloais",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Anhien",
                table: "NgonnguMns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "NgonnguMns",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Anhien",
                table: "Menus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Mangas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "GioHangs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Banners",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b822f53b-89be-4452-8f5a-9c4880cfe441");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "35c6f563-8a20-47c1-955d-4bcf2bd2b998", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEPj+1KLJi1BvCd8npbjSkPRWy1Kbg2SZpztE4cb39imBzLsoywSB5jUCNQFFJHS3SQ==" });

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
                name: "Meta",
                table: "TinTucs");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Theloais");

            migrationBuilder.DropColumn(
                name: "Anhien",
                table: "NgonnguMns");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "NgonnguMns");

            migrationBuilder.DropColumn(
                name: "Anhien",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "GioHangs");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Banners");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "e80c6188-2b55-4781-bbae-ad86bf923bfa");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "088443aa-5dae-4aa5-871c-44db7976ed7c", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEJ/fhOvfFXOCLF5OKXlYe9aadXtl6Frf2Jkh+inlAbn9SCZEczLL+Nas5y0Xbw6WRg==" });

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
