using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTravel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordFieldsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 8, 57, 23, 309, DateTimeKind.Utc).AddTicks(8191));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8737));
        }
    }
}
