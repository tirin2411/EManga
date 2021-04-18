using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class khuyenmaitheloai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "Khuyenmais");

            migrationBuilder.DropColumn(
                name: "TheLoaiId",
                table: "Khuyenmais");

            migrationBuilder.CreateTable(
                name: "KhuyenmaiTheloais",
                columns: table => new
                {
                    KhuyenmaiId = table.Column<int>(nullable: false),
                    TheLoaiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenmaiTheloais", x => new { x.KhuyenmaiId, x.TheLoaiId });
                    table.ForeignKey(
                        name: "FK_KhuyenmaiTheloais_Khuyenmais_KhuyenmaiId",
                        column: x => x.KhuyenmaiId,
                        principalTable: "Khuyenmais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuyenmaiTheloais_Theloais_TheLoaiId",
                        column: x => x.TheLoaiId,
                        principalTable: "Theloais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "6fb480f5-8023-4d54-9e86-7d2029546151");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "aad3265f-c003-4fec-a376-d04ca8093d66", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEHNlGWb9JZLWkvDMKouGLLJpYGW3oMqri4XvX4SZnyh7Q2iZ4sjJb2HIfnEs2xOnEw==" });

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
                name: "IX_KhuyenmaiTheloais_TheLoaiId",
                table: "KhuyenmaiTheloais",
                column: "TheLoaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhuyenmaiTheloais");

            migrationBuilder.AddColumn<int>(
                name: "MangaId",
                table: "Khuyenmais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TheLoaiId",
                table: "Khuyenmais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5a211df3-8578-4b83-bd8a-d3e0c27066ba");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "4a996704-cb29-4806-9c5f-722f51eaf0c0", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEFzkwbpIOnl9khiYPVRvyEWPIMtsQbjeONJA2EzHlHCFAMMDf/o5QMN7wwHhQbCn7Q==" });

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
                name: "IX_Khuyenmais_MangaId",
                table: "Khuyenmais",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Khuyenmais_TheLoaiId",
                table: "Khuyenmais",
                column: "TheLoaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Khuyenmais_Mangas_MangaId",
                table: "Khuyenmais",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Khuyenmais_Theloais_TheLoaiId",
                table: "Khuyenmais",
                column: "TheLoaiId",
                principalTable: "Theloais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
