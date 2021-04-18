using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class HTHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Payments",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaChiId",
                table: "DonHangs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoaDonId",
                table: "DonHangs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Ngaynhan",
                table: "DonHangs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "DonHangs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "DiaChis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ghichu",
                table: "DiaChis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sdt",
                table: "DiaChis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tennguoinhan",
                table: "DiaChis",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Anhien",
                table: "Banners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CC_NUM = table.Column<string>(nullable: true),
                    Holder_name = table.Column<string>(nullable: true),
                    Expire_date = table.Column<DateTime>(nullable: false),
                    DiaChiId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_DiaChis_DiaChiId",
                        column: x => x.DiaChiId,
                        principalTable: "DiaChis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHangHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonHangId = table.Column<int>(nullable: false),
                    Tongtien = table.Column<float>(nullable: false),
                    Trangthai = table.Column<int>(nullable: false),
                    Ghichu = table.Column<string>(nullable: true),
                    Ngaplap = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardId = table.Column<int>(nullable: false),
                    Creation_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    State_desc = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonHistories",
                columns: table => new
                {
                    HoaDonId = table.Column<int>(nullable: false),
                    State_desc = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonHistories", x => x.HoaDonId);
                    table.ForeignKey(
                        name: "FK_HoaDonHistories_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c1426bb8-7c56-4310-9b77-50b93b19f0f5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53ca57b6-828a-4f59-8947-c6c69c3ae33d", "AQAAAAEAACcQAAAAEC1uUeshhHaPD/IBWX+poDuqAW+R5um5X1eSc1bCwK7UKOAsQvNXAswApOS5pSkEhw==" });

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
                name: "IX_Payments_CreditCardId",
                table: "Payments",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_DiaChiId",
                table: "DonHangs",
                column: "DiaChiId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_HoaDonId",
                table: "DonHangs",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_PaymentId",
                table: "DonHangs",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChis_AppUserId",
                table: "DiaChis",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_DiaChiId",
                table: "CreditCards",
                column: "DiaChiId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_CreditCardId",
                table: "HoaDons",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaChis_AppUsers_AppUserId",
                table: "DiaChis",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_CreditCards_CreditCardId",
                table: "Payments",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaChis_AppUsers_AppUserId",
                table: "DiaChis");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHangs_DiaChis_DiaChiId",
                table: "DonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHangs_HoaDons_HoaDonId",
                table: "DonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHangs_Payments_PaymentId",
                table: "DonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_CreditCards_CreditCardId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "DonHangHistories");

            migrationBuilder.DropTable(
                name: "HoaDonHistories");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CreditCardId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_DonHangs_DiaChiId",
                table: "DonHangs");

            migrationBuilder.DropIndex(
                name: "IX_DonHangs_HoaDonId",
                table: "DonHangs");

            migrationBuilder.DropIndex(
                name: "IX_DonHangs_PaymentId",
                table: "DonHangs");

            migrationBuilder.DropIndex(
                name: "IX_DiaChis_AppUserId",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DiaChiId",
                table: "DonHangs");

            migrationBuilder.DropColumn(
                name: "HoaDonId",
                table: "DonHangs");

            migrationBuilder.DropColumn(
                name: "Ngaynhan",
                table: "DonHangs");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "DonHangs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "Ghichu",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "Sdt",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "Tennguoinhan",
                table: "DiaChis");

            migrationBuilder.DropColumn(
                name: "Anhien",
                table: "Banners");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "DiaChis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "67cb290f-c478-411d-a4bf-9f00dfe82979");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "78f7547c-406d-497a-b083-cf6949a6bea2", "AQAAAAEAACcQAAAAEN4HuAXdk4b63oFnSTagqro/RF08Lfl6MvM+zglCUmaVKoDfR/jEA9dewwfOKPmq2w==" });

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
                name: "IX_DiaChis_UserId",
                table: "DiaChis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaChis_AppUsers_UserId",
                table: "DiaChis",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}