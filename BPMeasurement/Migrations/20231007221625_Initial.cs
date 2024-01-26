using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPMeasurement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "BPMeasurements",
                columns: table => new
                {
                    BPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMeasurements", x => x.BPId);
                    table.ForeignKey(
                        name: "FK_BPMeasurements_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "Name" },
                values: new object[,]
                {
                    { "A", "Standing" },
                    { "L", "Lying Down" },
                    { "T", "Sitting" }
                });

            migrationBuilder.InsertData(
                table: "BPMeasurements",
                columns: new[] { "BPId", "Date", "Diastolic", "PositionId", "Systolic" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, "A", 120 },
                    { 2, new DateTime(2023, 10, 7, 18, 16, 25, 677, DateTimeKind.Local).AddTicks(1991), 121, "L", 181 },
                    { 3, new DateTime(2023, 10, 7, 18, 16, 25, 677, DateTimeKind.Local).AddTicks(2028), 90, "T", 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BPMeasurements_PositionId",
                table: "BPMeasurements",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BPMeasurements");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
