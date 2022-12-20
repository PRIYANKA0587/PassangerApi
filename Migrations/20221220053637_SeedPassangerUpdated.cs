using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassengerApi.Migrations
{
    public partial class SeedPassengerUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 20, 11, 6, 36, 750, DateTimeKind.Local).AddTicks(1087), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 20, 10, 50, 43, 136, DateTimeKind.Local).AddTicks(1555), new DateTime(2022, 12, 20, 10, 50, 43, 136, DateTimeKind.Local).AddTicks(1566) });
        }
    }
}
