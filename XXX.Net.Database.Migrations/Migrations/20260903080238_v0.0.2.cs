using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvLocation_SysTenant_TenantId",
                table: "InvLocation");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "InvLocation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassLevel",
                table: "InvLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "InvLocation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "InvLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvLocation_ParentId",
                table: "InvLocation",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_InvLocation_Path",
                table: "InvLocation",
                column: "Path");

            migrationBuilder.AddForeignKey(
                name: "FK_InvLocation_SysTenant_TenantId",
                table: "InvLocation",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvLocation_SysTenant_TenantId",
                table: "InvLocation");

            migrationBuilder.DropIndex(
                name: "IX_InvLocation_ParentId",
                table: "InvLocation");

            migrationBuilder.DropIndex(
                name: "IX_InvLocation_Path",
                table: "InvLocation");

            migrationBuilder.DropColumn(
                name: "ClassLevel",
                table: "InvLocation");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "InvLocation");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "InvLocation");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "InvLocation",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_InvLocation_SysTenant_TenantId",
                table: "InvLocation",
                column: "TenantId",
                principalTable: "SysTenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
