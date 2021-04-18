using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hinh = table.Column<string>(nullable: false),
                    ThuTu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaChis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diachi = table.Column<string>(nullable: false),
                    TinhThanh = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDat = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    NguoiNhan = table.Column<string>(nullable: true),
                    DiaChiNhan = table.Column<string>(maxLength: 200, nullable: false),
                    SDT = table.Column<string>(nullable: true),
                    Tinhtrang = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Giaodichs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayGd = table.Column<DateTime>(nullable: false),
                    ExternalTransactionId = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    Fee = table.Column<float>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Provider = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giaodichs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khuyenmais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    ApplyForAll = table.Column<bool>(nullable: false),
                    DiscountPercent = table.Column<int>(nullable: true),
                    DiscountAmount = table.Column<float>(nullable: true),
                    MangaIds = table.Column<string>(nullable: true),
                    MangaTheloaiIds = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khuyenmais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LienHes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(nullable: false),
                    SDT = table.Column<string>(maxLength: 20, nullable: false),
                    NoiDung = table.Column<string>(nullable: false),
                    NgayGui = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMenu = table.Column<string>(nullable: false),
                    ThuTu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NgonnguMns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgonnguMns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoLuotTruyCaps",
                columns: table => new
                {
                    Dem = table.Column<long>(nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoLuotTruyCaps", x => x.Dem);
                });

            migrationBuilder.CreateTable(
                name: "TacGias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTacGia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theloais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTL = table.Column<string>(nullable: false),
                    Thutu = table.Column<int>(nullable: false),
                    Anhien = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theloais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinTucs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(maxLength: 50, nullable: false),
                    Hinh = table.Column<string>(maxLength: 200, nullable: false),
                    NoiDung = table.Column<string>(nullable: false),
                    NgayCapNhat = table.Column<DateTime>(nullable: false),
                    AnHien = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: false),
                    Gia = table.Column<float>(nullable: false),
                    Giagoc = table.Column<float>(nullable: false),
                    Anhien = table.Column<bool>(nullable: false, defaultValue: true),
                    NgonnguId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangas_NgonnguMns_NgonnguId",
                        column: x => x.NgonnguId,
                        principalTable: "NgonnguMns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHangDetails",
                columns: table => new
                {
                    DonHangId = table.Column<int>(nullable: false),
                    MangaId = table.Column<int>(nullable: false),
                    Gia = table.Column<float>(nullable: false),
                    Soluongdat = table.Column<int>(nullable: false),
                    Tongtien = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangDetails", x => new { x.DonHangId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_DonHangDetails_DonHangs_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangDetails_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(nullable: false),
                    Gia = table.Column<float>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangs_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaDetails",
                columns: table => new
                {
                    MangaId = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    TinhtrangMn = table.Column<int>(nullable: false),
                    Mota = table.Column<string>(nullable: true),
                    Tacgia = table.Column<string>(nullable: true),
                    NamXB = table.Column<string>(nullable: true),
                    Sotrang = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaDetails", x => x.MangaId);
                    table.ForeignKey(
                        name: "FK_MangaDetails_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(nullable: false),
                    LinkAnh = table.Column<string>(maxLength: 200, nullable: false),
                    ChuThich = table.Column<string>(maxLength: 200, nullable: true),
                    Anhmacdinh = table.Column<bool>(nullable: false),
                    ThuTu = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MangaImages_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(nullable: false),
                    TieuDe = table.Column<string>(maxLength: 50, nullable: false),
                    NoiDung = table.Column<string>(maxLength: 200, nullable: false),
                    NgayComment = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MComments_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MnTheloais",
                columns: table => new
                {
                    MangaId = table.Column<int>(nullable: false),
                    TheLoaiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MnTheloais", x => new { x.MangaId, x.TheLoaiId });
                    table.ForeignKey(
                        name: "FK_MnTheloais_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MnTheloais_Theloais_TheLoaiId",
                        column: x => x.TheLoaiId,
                        principalTable: "Theloais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHangDetails_MangaId",
                table: "DonHangDetails",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_MangaId",
                table: "GioHangs",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaImages_MangaId",
                table: "MangaImages",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_NgonnguId",
                table: "Mangas",
                column: "NgonnguId");

            migrationBuilder.CreateIndex(
                name: "IX_MComments_MangaId",
                table: "MComments",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MnTheloais_TheLoaiId",
                table: "MnTheloais",
                column: "TheLoaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "DiaChis");

            migrationBuilder.DropTable(
                name: "DonHangDetails");

            migrationBuilder.DropTable(
                name: "Giaodichs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "Khuyenmais");

            migrationBuilder.DropTable(
                name: "LienHes");

            migrationBuilder.DropTable(
                name: "MangaDetails");

            migrationBuilder.DropTable(
                name: "MangaImages");

            migrationBuilder.DropTable(
                name: "MComments");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "MnTheloais");

            migrationBuilder.DropTable(
                name: "SoLuotTruyCaps");

            migrationBuilder.DropTable(
                name: "TacGias");

            migrationBuilder.DropTable(
                name: "TinTucs");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Theloais");

            migrationBuilder.DropTable(
                name: "NgonnguMns");
        }
    }
}
