using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplicationMVCCrudwithAjax.Migrations
{
    /// <inheritdoc />
    public partial class addedSomeEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "City", "Code", "Dob", "DobStr", "Gender", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Yes", "Mumbai", 101, new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "12-05-1990", "Female", "alice.jpg", "Alice" },
                    { 2, "Yes", "Delhi", 102, new DateTime(1985, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "23-08-1985", "Male", "bob.jpg", "Bob" },
                    { 3, "No", "Bangalore", 103, new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "15-03-1992", "Male", "charlie.jpg", "Charlie" },
                    { 4, "Yes", "Chennai", 104, new DateTime(1995, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "05-12-1995", "Female", "diana.jpg", "Diana" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
