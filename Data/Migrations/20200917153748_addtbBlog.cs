using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addtbBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hinh",
                table: "TinTucs");

            migrationBuilder.AddColumn<string>(
                name: "HinhAnhtintuc",
                table: "TinTucs",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoiDungTomTat",
                table: "TinTucs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tacgia",
                table: "TinTucs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(maxLength: 50, nullable: false),
                    HinhAnhblog = table.Column<string>(maxLength: 200, nullable: false),
                    NoiDungBlog = table.Column<string>(nullable: false),
                    NgayCapNhat = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    AnHien = table.Column<bool>(nullable: false, defaultValue: true),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "2fbd283f-27d3-45e8-bf55-2e4f7682c4ed");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "66681dd6-d42a-41e6-bb0a-99be1da5817b", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEAe7DeoZ+ghIJvEfAUjTj85ryRT8qcMjLVFJ9pnzvAiGQ1D5lRPRchhCzcH17NjI5g==" });

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
                name: "Blogs");

            migrationBuilder.DropColumn(
                name: "HinhAnhtintuc",
                table: "TinTucs");

            migrationBuilder.DropColumn(
                name: "NoiDungTomTat",
                table: "TinTucs");

            migrationBuilder.DropColumn(
                name: "Tacgia",
                table: "TinTucs");

            migrationBuilder.AddColumn<string>(
                name: "Hinh",
                table: "TinTucs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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
    }
}
