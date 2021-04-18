using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateShipTableRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "ShipmentTableRates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "ShipmentTableRates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RevenueStatisticViewModels",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    Revenues = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "e0c059bb-2c98-4703-997e-69c5c3f58cc0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "f8fcf22f-74f6-493e-b676-f79b50ac3d5c", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEDF2p158z1D4LChl7rewq/L1hFWLV2AnHFbffTsYVw5KmvJPnryyoWsePnZuoNRxpg==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevenueStatisticViewModels");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "ShipmentTableRates");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "ShipmentTableRates");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a0b641af-b081-4bd8-93c9-e3d880a45a15");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "187017a6-a350-4987-bf1f-ae1a8cc769b2", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEGLjBiK6ITjs+JhUg2zUDhwcZZmrpuOsRjLlO6tBylXCt7yJxLTAumEhlycBwwq5Pw==" });

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
