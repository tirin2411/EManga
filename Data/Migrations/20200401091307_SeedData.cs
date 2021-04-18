using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of FMN" },
                    { "HomeKeyword", "This is Keyword of FMN" },
                    { "HomeDescription", "This is Description of FMN" }
                });

            migrationBuilder.InsertData(
                table: "NgonnguMns",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vietnamese" },
                    { 2, "Japanese" }
                });

            migrationBuilder.InsertData(
                table: "Theloais",
                columns: new[] { "Id", "TenTL", "Thutu" },
                values: new object[,]
                {
                    { 1, "Hành Động", 0 },
                    { 2, "Hài Hước", 0 },
                    { 3, "Kinh Dị", 0 },
                    { 4, "Trinh Thám", 0 }
                });

            migrationBuilder.InsertData(
                table: "Mangas",
                columns: new[] { "Id", "Anhien", "Gia", "Giagoc", "Ma", "NgonnguId", "Ten" },
                values: new object[] { 1, true, 50000f, 50000f, null, 1, "OnePice Tap 1" });

            migrationBuilder.InsertData(
                table: "Mangas",
                columns: new[] { "Id", "Anhien", "Gia", "Giagoc", "Ma", "NgonnguId", "Ten" },
                values: new object[] { 2, true, 30000f, 30000f, null, 1, "Conan Tap 10" });

            migrationBuilder.InsertData(
                table: "MangaDetails",
                columns: new[] { "MangaId", "Mota", "NamXB", "SoLuong", "Sotrang", "Tacgia", "TinhtrangMn" },
                values: new object[,]
                {
                    { 1, "Hay lam ne hehe", "1234", 1, 90, "vvv", 1 },
                    { 2, "Hấp dẫn nè", "3452", 1, 97, "fdsf", 1 }
                });

            migrationBuilder.InsertData(
                table: "MnTheloais",
                columns: new[] { "MangaId", "TheLoaiId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "MangaDetails",
                keyColumn: "MangaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MangaDetails",
                keyColumn: "MangaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MnTheloais",
                keyColumns: new[] { "MangaId", "TheLoaiId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MnTheloais",
                keyColumns: new[] { "MangaId", "TheLoaiId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MnTheloais",
                keyColumns: new[] { "MangaId", "TheLoaiId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "NgonnguMns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Theloais",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Theloais",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Mangas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mangas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Theloais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Theloais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NgonnguMns",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
