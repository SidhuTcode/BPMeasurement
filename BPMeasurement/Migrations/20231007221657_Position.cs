using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPMeasurement.Migrations
{
    /// <inheritdoc />
    public partial class Position : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 10, 7, 18, 16, 57, 646, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 10, 7, 18, 16, 57, 646, DateTimeKind.Local).AddTicks(945));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 10, 7, 18, 16, 25, 677, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 10, 7, 18, 16, 25, 677, DateTimeKind.Local).AddTicks(2028));
        }
    }
}
