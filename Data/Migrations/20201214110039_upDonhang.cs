using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class upDonhang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DiaChiNhan",
                table: "DonHangs",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "TinhtrangThanhtoan",
                table: "DonHangs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TongTien",
                table: "DonHangs",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f39771a8-185c-4bba-8100-098d0f2109b7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "d8b7851c-54e5-4b0b-bfd6-3fbb90543b4a", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEGb4H4Xn39dU1SQlT6X+qZQgqhtRdOcTlRw4fiWomGin37wDJXNR/OLnLuDmcB0BHA==" });

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
                name: "TinhtrangThanhtoan",
                table: "DonHangs");

            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "DonHangs");

            migrationBuilder.AlterColumn<string>(
                name: "DiaChiNhan",
                table: "DonHangs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ee37d92c-02e2-47f1-adf6-9da93e5cf360");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "ab47ca11-2701-4516-ab71-a2b278fe960f", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAELctGGY6SHTDpiu0iJ957W1iwmAr/beYiPBQmN/Xgjp00dhm6TBoLZL7xBT+WrHM7g==" });

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
