using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvDocument_SysTenant_TenantId",
                table: "InvDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_InvDocumentItem_SysTenant_TenantId",
                table: "InvDocumentItem");

            migrationBuilder.DropIndex(
                name: "IX_InvDocumentItem_TenantId",
                table: "InvDocumentItem");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "InvDocumentItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "InvDocumentItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_InvDocumentItem_TenantId",
                table: "InvDocumentItem",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvDocument_SysTenant_TenantId",
                table: "InvDocument",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvDocumentItem_SysTenant_TenantId",
                table: "InvDocumentItem",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
