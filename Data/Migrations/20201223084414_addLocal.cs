using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    TelephoneCode = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    LatiLongTude = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    LatiLongTude = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_DistrictId",
                table: "Wards",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "e3f24f5d-1078-4926-8ae1-9d19abdee8e1");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "823e4862-dc80-4fb8-a4a3-c2edd1121bca", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEI07tpxMJXiMYvOdSowUDTlGhjYxVubo32Y7+71uYYpJB9PGzR8ub20a/n63LAeJ5A==" });

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
                name: "IX_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
