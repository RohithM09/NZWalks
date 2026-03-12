using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6ed3c98e-c86c-4649-a1dc-7497dff26bb7"), "Easy" },
                    { new Guid("761cbaa8-587d-41f2-a940-8b02b2dbdc33"), "Hard" },
                    { new Guid("b47d095c-f4ce-45a9-a047-2a19678d396c"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0a816c33-188b-4a5c-8c0a-b9efe13d20f6"), "NTL", "Northland", null },
                    { new Guid("0cd62230-317a-4200-bc4f-d5a02c5286c6"), "AKL", "Auckland", "https://images.pexels.com/photos/36412493/pexels-photo-36412493.jpeg" },
                    { new Guid("4f5f23e8-4e76-4d61-9e41-12e50e1a75ac"), "BOP", "Bay of plenty", null },
                    { new Guid("77c450f5-bbe8-44a3-93f8-6643146e55ed"), "WGN", "Wellington", null },
                    { new Guid("969ad4b5-ed4c-496d-bbb5-587999f6eaf3"), "NSN", "Nelson", null },
                    { new Guid("d1852724-7413-48eb-b3b3-851314229a34"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6ed3c98e-c86c-4649-a1dc-7497dff26bb7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("761cbaa8-587d-41f2-a940-8b02b2dbdc33"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b47d095c-f4ce-45a9-a047-2a19678d396c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0a816c33-188b-4a5c-8c0a-b9efe13d20f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0cd62230-317a-4200-bc4f-d5a02c5286c6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4f5f23e8-4e76-4d61-9e41-12e50e1a75ac"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("77c450f5-bbe8-44a3-93f8-6643146e55ed"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("969ad4b5-ed4c-496d-bbb5-587999f6eaf3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d1852724-7413-48eb-b3b3-851314229a34"));
        }
    }
}
