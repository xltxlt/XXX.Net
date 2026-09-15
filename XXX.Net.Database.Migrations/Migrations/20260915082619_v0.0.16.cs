using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v0016 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "PmFlowItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanEndTime",
                table: "PmFlowItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanStartTime",
                table: "PmFlowItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "PmFlowItem",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "PmFlowItem");

            migrationBuilder.DropColumn(
                name: "PlanEndTime",
                table: "PmFlowItem");

            migrationBuilder.DropColumn(
                name: "PlanStartTime",
                table: "PmFlowItem");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "PmFlowItem");
        }
    }
}
