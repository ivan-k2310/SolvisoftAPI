using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolvisoftAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "LastUpdated", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", 999.99m, 50 },
                    { 2, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone", 499.99m, 150 },
                    { 3, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tablet", 399.99m, 100 },
                    { 4, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer", 1449.99m, 5 },
                    { 5, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitor", 160.00m, 34 },
                    { 6, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keyboard", 89.99m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);
        }
    }
}
