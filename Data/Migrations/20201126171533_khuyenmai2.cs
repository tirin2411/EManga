using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class khuyenmai2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "MangaIds",
                table: "Khuyenmais");

            migrationBuilder.DropColumn(
                name: "MangaTheloaiIds",
                table: "Khuyenmais");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "Khuyenmais",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CouponCode",
                table: "Khuyenmais",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MangaId",
                table: "Khuyenmais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaximumDiscountedQuantity",
                table: "Khuyenmais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TheLoaiId",
                table: "Khuyenmais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Khuyenmai",
                table: "DonHangDetails",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "KhuyenmaiLichsuSudungs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhuyenmaiId = table.Column<int>(nullable: false),
                    DonHangId = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenmaiLichsuSudungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuyenmaiLichsuSudungs_DonHangs_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuyenmaiLichsuSudungs_Khuyenmais_KhuyenmaiId",
                        column: x => x.KhuyenmaiId,
                        principalTable: "Khuyenmais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenmaiMangas",
                columns: table => new
                {
                    KhuyenmaiId = table.Column<int>(nullable: false),
                    MangaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenmaiMangas", x => new { x.KhuyenmaiId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_KhuyenmaiMangas_Khuyenmais_KhuyenmaiId",
                        column: x => x.KhuyenmaiId,
                        principalTable: "Khuyenmais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuyenmaiMangas_Mangas_MangaId",
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
                name: "IX_KhuyenmaiLichsuSudungs_DonHangId",
                table: "KhuyenmaiLichsuSudungs",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenmaiLichsuSudungs_KhuyenmaiId",
                table: "KhuyenmaiLichsuSudungs",
                column: "KhuyenmaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenmaiMangas_MangaId",
                table: "KhuyenmaiMangas",
                column: "MangaId");

          
           
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "KhuyenmaiLichsuSudungs");

            migrationBuilder.DropTable(
                name: "KhuyenmaiMangas");

            
            migrationBuilder.DropIndex(
                name: "IX_Khuyenmais_MangaId",
                table: "Khuyenmais");

            migrationBuilder.DropIndex(
                name: "IX_Khuyenmais_TheLoaiId",
                table: "Khuyenmais");

            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "Khuyenmais");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "Khuyenmais");

            migrationBuilder.DropColumn(
                name: "MaximumDiscountedQuantity",
                table: "Khuyenmais");

            migrationBuilder.DropColumn(
                name: "TheLoaiId",
                table: "Khuyenmais");

            migrationBuilder.DropColumn(
                name: "Khuyenmai",
                table: "DonHangDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "Khuyenmais",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "MangaIds",
                table: "Khuyenmais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MangaTheloaiIds",
                table: "Khuyenmais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "59b85e95-2edb-4c67-9140-530c7600d826");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "e8ddfeac-86de-49ac-80f1-deb0a0bf9415", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEJTwQRejCoCodPvrv9Gf5kh0SujkxWqHhSLbWHET3zjGDOxYygP1DgO8b0P1bGo73Q==" });

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
