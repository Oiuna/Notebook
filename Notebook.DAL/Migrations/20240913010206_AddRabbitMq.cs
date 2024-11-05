using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRabbitMq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 13, 1, 2, 5, 566, DateTimeKind.Utc).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 13, 1, 2, 5, 569, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "UserToken",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RefreshTokenExpireTime",
                value: new DateTime(2024, 9, 20, 1, 2, 5, 569, DateTimeKind.Utc).AddTicks(8964));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
