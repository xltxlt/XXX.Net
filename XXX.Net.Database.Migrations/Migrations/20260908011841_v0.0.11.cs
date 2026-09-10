using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v0011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassLevel",
                table: "SysTenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "SysTenant",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "SysTenant",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "SysTenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SysTenant_ParentId",
                table: "SysTenant",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SysTenant_Path",
                table: "SysTenant",
                column: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SysTenant_ParentId",
                table: "SysTenant");

            migrationBuilder.DropIndex(
                name: "IX_SysTenant_Path",
                table: "SysTenant");

            migrationBuilder.DropColumn(
                name: "ClassLevel",
                table: "SysTenant");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "SysTenant");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "SysTenant");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "SysTenant");
        }
    }
}
