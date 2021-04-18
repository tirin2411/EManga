using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RevenuesStatisticSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE GetRevenueStatistic
                        @fromDate varchar(max),
                        @toDate varchar(max)
                    AS
                    BEGIN
                        select 
                        o.NgayDat as Date,
                        sum(od.Tongtien) as Revenues 
                        from DonHangs o
                        inner join DonHangDetails od
                        on o.Id = od.DonHangId
                        where o.NgayDat <= CAST(@toDate as date) and o.NgayDat >= CAST(@fromDate as date)
                        group by o.NgayDat
                    END";
            migrationBuilder.Sql(sp);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE GetRevenueStatistic";
            migrationBuilder.Sql(sp);


            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a82842af-b117-4422-8d1d-8a3716b19809");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "9706cb3a-36bd-4ca1-b663-5c01479665a4", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEL7ij2uLwWaYkY+84mJ3LqnKV930FjgsocGRpXzipskZj2bG3CFfAlxBo/7ojAUSsg==" });

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
