using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v005 : Migration
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

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "InvDocumentItem",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_InvDocumentItem_DocumentId",
                table: "InvDocumentItem",
                newName: "IX_InvDocumentItem_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvDocument_SysTenant_TenantId",
                table: "InvDocument",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvDocumentItem_InvDocument_ParentId",
                table: "InvDocumentItem",
                column: "ParentId",
                principalTable: "InvDocument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvDocumentItem_SysTenant_TenantId",
                table: "InvDocumentItem",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvDocument_SysTenant_TenantId",
                table: "InvDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_InvDocumentItem_InvDocument_ParentId",
                table: "InvDocumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvDocumentItem_SysTenant_TenantId",
                table: "InvDocumentItem");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "InvDocumentItem",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_InvDocumentItem_ParentId",
                table: "InvDocumentItem",
                newName: "IX_InvDocumentItem_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvDocument_SysTenant_TenantId",
                table: "InvDocument",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvDocumentItem_SysTenant_TenantId",
                table: "InvDocumentItem",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
