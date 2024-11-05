using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 13, 0, 54, 5, 432, DateTimeKind.Utc).AddTicks(945));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 13, 0, 54, 5, 435, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "UserToken",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RefreshTokenExpireTime",
                value: new DateTime(2024, 9, 20, 0, 54, 5, 436, DateTimeKind.Utc).AddTicks(2245));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 5, 9, 11, 47, 460, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 5, 9, 11, 47, 463, DateTimeKind.Utc).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "UserToken",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RefreshTokenExpireTime",
                value: new DateTime(2024, 9, 12, 9, 11, 47, 463, DateTimeKind.Utc).AddTicks(6147));
        }
    }
}
