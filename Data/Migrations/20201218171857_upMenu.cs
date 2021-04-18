using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class upMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    CustomLink = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true),
                    ThuTu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "96f62b9a-14f0-413a-ac31-f529b193ef49");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "bb26b8f3-8dc5-45cb-a66a-a7e8fcc7b9af", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEJYIsyRLfsPfu8XsbMu7VZFFsHji9tvM8IYtwsiaJq1eA6UOrkdqr0b8Mi4aDUxphQ==" });

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
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

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
    }
}
