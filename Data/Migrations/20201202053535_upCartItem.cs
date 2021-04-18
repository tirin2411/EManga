using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class upCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_Mangas_MangaId",
                table: "GioHangs");

            migrationBuilder.DropIndex(
                name: "IX_GioHangs_MangaId",
                table: "GioHangs");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "GioHangs");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "GioHangs");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "GioHangs");

            migrationBuilder.AddColumn<string>(
                name: "CouponCode",
                table: "GioHangs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "GioHangs",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "GioHangs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GioHangDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GioHangId = table.Column<int>(nullable: false),
                    MangaId = table.Column<int>(nullable: false),
                    Gia = table.Column<float>(nullable: false),
                    Soluongdat = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangDetails_GioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "GioHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangDetails_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9a7f9f7e-d48f-48a8-8f55-96eeb3bf2333");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "fcc18f67-ea39-46f8-8d2f-aae73f46b393", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEBjRu6XBFw9VvwZ3A34RwIct0VoVmZ0q/qS5uOdjS0dfYulU6MAICg1uHsbCmtxaIw==" });

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
                name: "IX_GioHangDetails_GioHangId",
                table: "GioHangDetails",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangDetails_MangaId",
                table: "GioHangDetails",
                column: "MangaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHangDetails");

            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "GioHangs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "GioHangs");

            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "GioHangs");

            migrationBuilder.AddColumn<float>(
                name: "Gia",
                table: "GioHangs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "MangaId",
                table: "GioHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "GioHangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "e8b4163b-958a-4f43-8419-da46788bc456");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "37d8118b-c609-487d-899a-103167752578", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEOHBiQymLbfKTW6SWU1kl8/z+i+oVLi2wenQP5Ss+4O7rpU4269Jn6F+ZFV91GZI2g==" });

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
                name: "IX_GioHangs_MangaId",
                table: "GioHangs",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_Mangas_MangaId",
                table: "GioHangs",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
