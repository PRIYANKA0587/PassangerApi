using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassengerApi.Migrations
{
    public partial class SeedPassengerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Passengers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Passengers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adhar",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "Adhar", "Age", "CreatedDate", "Email", "MobileNumber", "Name", "UpdatedDate" },
                values: new object[] { 1, "433454657612", 30, new DateTime(2022, 12, 20, 10, 50, 43, 136, DateTimeKind.Local).AddTicks(1555), "sobarp@gmail.com", "656095445", "Priyanka", new DateTime(2022, 12, 20, 10, 50, 43, 136, DateTimeKind.Local).AddTicks(1566) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "Passengers",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Adhar",
                table: "Passengers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
