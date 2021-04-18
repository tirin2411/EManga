using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addtbPaym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GioiTinh",
                table: "AppUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatus = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

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
                columns: new[] { "ConcurrencyStamp", "GioiTinh", "PasswordHash" },
                values: new object[] { "78f7547c-406d-497a-b083-cf6949a6bea2", 1, "AQAAAAEAACcQAAAAEN4HuAXdk4b63oFnSTagqro/RF08Lfl6MvM+zglCUmaVKoDfR/jEA9dewwfOKPmq2w==" });

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
                name: "Payments");

            migrationBuilder.AlterColumn<bool>(
                name: "GioiTinh",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "da691773-0f24-4863-a0a1-e7ad9efc1936");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "GioiTinh", "PasswordHash" },
                values: new object[] { "523afc1c-8a42-4eb1-8d2d-73c136f83251", true, "AQAAAAEAACcQAAAAEJwAOTAgUF83+b1jQAWymfd7o4uamyvyRfrBeE3vG3ToQOp8RDsvX59e4Of41BI2hQ==" });

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
