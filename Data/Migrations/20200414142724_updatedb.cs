using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhat",
                table: "TinTucs",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayComment",
                table: "MComments",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "Khuyenmais",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayGd",
                table: "Giaodichs",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "DonHangs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NguoiNhan",
                table: "DonHangs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDat",
                table: "DonHangs",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8f36413d-bc7d-4db3-abf9-8fd766cc9a60");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95b9779b-0d56-4592-9240-4b0eee80c6d5", "AQAAAAEAACcQAAAAECJrrN0lo/mV/f8bFeo2URQYEIRiikNfQ1CkMJKDdh08DMlFMSN5aTv2aIctyT8liA==" });

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
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhat",
                table: "TinTucs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayComment",
                table: "MComments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "Khuyenmais",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayGd",
                table: "Giaodichs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "DonHangs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NguoiNhan",
                table: "DonHangs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDat",
                table: "DonHangs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "67130f0b-dbcc-43fc-a652-d06c1cec5d04");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a0ce7e2-b59e-4caa-91c5-3e948062fff0", "AQAAAAEAACcQAAAAEHkW9CONlOzAsn5vJ49ROUu69EniXBv2r7uezQliCoz2e9O8tUrQXpiWlN2951gecA==" });

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
