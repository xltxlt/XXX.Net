using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v0013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SysDepartmentId",
                table: "SysUserDepRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysUserDepRole_SysDepartmentId",
                table: "SysUserDepRole",
                column: "SysDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SysUserDepRole_SysDepartment_SysDepartmentId",
                table: "SysUserDepRole",
                column: "SysDepartmentId",
                principalTable: "SysDepartment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysUserDepRole_SysDepartment_SysDepartmentId",
                table: "SysUserDepRole");

            migrationBuilder.DropIndex(
                name: "IX_SysUserDepRole_SysDepartmentId",
                table: "SysUserDepRole");

            migrationBuilder.DropColumn(
                name: "SysDepartmentId",
                table: "SysUserDepRole");
        }
    }
}
