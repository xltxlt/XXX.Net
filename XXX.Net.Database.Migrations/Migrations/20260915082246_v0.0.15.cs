using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v0015 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkflowId",
                table: "PmFlowTemp",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WorkflowDefinitionId",
                table: "PmFlowTemp",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PmFlowTemp",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PmFlowItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PmFlowTempId = table.Column<long>(type: "bigint", nullable: false),
                    WorkflowId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    WorkflowDefinitionId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmFlowItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmFlowItem_SysTenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "SysTenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmFlowItem_TenantId",
                table: "PmFlowItem",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmFlowItem");

            migrationBuilder.AlterColumn<string>(
                name: "WorkflowId",
                table: "PmFlowTemp",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "WorkflowDefinitionId",
                table: "PmFlowTemp",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PmFlowTemp",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);
        }
    }
}
