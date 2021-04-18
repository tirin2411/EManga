using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class upseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "614183e3-a180-496d-8a6f-d946eda829a1");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "a268198c-33de-4f4e-b498-87ca0b7e2f57", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAELVG/U3416pceFmsaRkd+1N76h71v3mJnDOIwDoh3PdbNUNnQseU2Q+JduJ4M8XKQg==" });

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

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Anhien", "Meta", "TenMenu", "ThuTu" },
                values: new object[,]
                {
                    { 1, true, "menu-header", "Menu Header", 1 },
                    { 2, true, "menu-footer", "Menu Footer", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "79541fe9-90dd-4715-99c1-e4ea3449672c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "58ec46b4-859d-437e-b2bc-cb5863f38c29", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAELmgQWWNAjm0pNDuO5mPh0u5wZ7FioP/7sC7aCX3zyuahUCrrSnU18XrE7QcEg8oEw==" });

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
