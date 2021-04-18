using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class umenui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "ParentId",
            //    table: "MenuItems",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "25c5f5a9-2fa1-4838-9cd5-c880fe4c6ec7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "4eb83ab3-141b-411e-b954-5cb31830b9d8", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEOKjeejwQ/nlQRUPd9Lm7NqxjGKe4gF18bZgVuSpK7h6wiRzedN1VUYbSYx21Iyfjg==" });

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_MenuItems_ParentId",
            //    table: "MenuItems",
            //    column: "ParentId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MenuItems_MenuItems_ParentId",
            //    table: "MenuItems",
            //    column: "ParentId",
            //    principalTable: "MenuItems",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuItems_ParentId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_ParentId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c9cf8b89-1b68-47fa-a446-e1d212b24351");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Dob", "PasswordHash" },
                values: new object[] { "a31fdbf2-dae0-4b98-85db-27802816d486", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAELTO4D10AHfw8AcnUqY6idvsNldt2O7kh6bNDIULjSt8axGVPNZkqSArMsk3knFNGA==" });

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
