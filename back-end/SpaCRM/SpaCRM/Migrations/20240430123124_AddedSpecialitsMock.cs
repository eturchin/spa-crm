using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpaCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpecialitsMock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialists",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "ModificationDate" },
                values: new object[,]
                {
                    { new Guid("8137d19c-84d1-499b-9277-de2bfff82fee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вероника", "Агафьева", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa5ee78e-201d-4c0f-9e08-30a7ed39f96c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Андрей", "Золоторёв", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c34d1827-9768-4873-8e8a-88bf6db5a2dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Владимир", "Квасов", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2b3e4b0-e5db-4814-b504-2aa28f683bb7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Екатерина", "Иванова", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: new Guid("8137d19c-84d1-499b-9277-de2bfff82fee"));

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: new Guid("aa5ee78e-201d-4c0f-9e08-30a7ed39f96c"));

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: new Guid("c34d1827-9768-4873-8e8a-88bf6db5a2dc"));

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "Id",
                keyValue: new Guid("e2b3e4b0-e5db-4814-b504-2aa28f683bb7"));
        }
    }
}
