using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerformanceAnalyzerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPerformanceResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerformanceResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadTime = table.Column<double>(type: "float", nullable: false),
                    ResourceCount = table.Column<int>(type: "int", nullable: false),
                    TotalSize = table.Column<long>(type: "bigint", nullable: false),
                    AnalyzedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceResults");
        }
    }
}
