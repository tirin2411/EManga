using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addShipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    CreateById = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_DonHangs_OrderId",
                        column: x => x.OrderId,
                        principalTable: "DonHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentTableRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistricId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ShippingPrice = table.Column<decimal>(nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentTableRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false),
                    MangaId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DonHangDetailDonHangId = table.Column<int>(nullable: true),
                    DonHangDetailMangaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_DonHangDetails_DonHangDetailDonHangId_DonHangDetailMangaId",
                        columns: x => new { x.DonHangDetailDonHangId, x.DonHangDetailMangaId },
                        principalTable: "DonHangDetails",
                        principalColumns: new[] { "DonHangId", "MangaId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "adca3a20-06ab-4f00-82bb-f35635ceb64f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "bf0ea9c3-da69-4f7a-874c-1c1b69c6b4d8", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEA96AXx0X/Lodf5bXZyqrW0lpxHEFSuH4HBomm8GYnGox+9/TCVPevOYUAcEYkP2tA==" });

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
                name: "IX_ShipmentItems_MangaId",
                table: "ShipmentItems",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItems_ShipmentId",
                table: "ShipmentItems",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItems_DonHangDetailDonHangId_DonHangDetailMangaId",
                table: "ShipmentItems",
                columns: new[] { "DonHangDetailDonHangId", "DonHangDetailMangaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderId",
                table: "Shipments",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipmentItems");

            migrationBuilder.DropTable(
                name: "ShipmentTableRates");

            migrationBuilder.DropTable(
                name: "Shipments");

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
