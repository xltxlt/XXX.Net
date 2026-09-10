using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXX.Net.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v0014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ding_talk_dept",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    SysDepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    DeptId = table.Column<long>(type: "bigint", nullable: false),
                    parent_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ding_talk_dept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DingTalkRoleUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    DingTalkUserId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SysRoleId = table.Column<long>(type: "bigint", nullable: true),
                    groupId = table.Column<long>(type: "bigint", nullable: false),
                    groupName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    roleId = table.Column<long>(type: "bigint", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DingTalkRoleUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DingTalkTenantApp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CorpId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallbackToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallbackEncodingAesKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DingTalkTenantApp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DingTalkTenantApp_SysTenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "SysTenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DingTalkUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    SysUserId = table.Column<long>(type: "bigint", nullable: false),
                    DingTalkUserId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UnionId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    JobNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DeptId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Dept = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SysPositionId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DingTalkUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DingTalkUser_SysUser_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DingTalkWokerflowLog",
                columns: table => new
                {
                    instanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkflowId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isReturn = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taskId = table.Column<long>(type: "bigint", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DingTalkWokerflowLog", x => x.instanceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DingTalkTenantApp_TenantId",
                table: "DingTalkTenantApp",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_DingTalkUser_SysUserId",
                table: "DingTalkUser",
                column: "SysUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ding_talk_dept");

            migrationBuilder.DropTable(
                name: "DingTalkRoleUser");

            migrationBuilder.DropTable(
                name: "DingTalkTenantApp");

            migrationBuilder.DropTable(
                name: "DingTalkUser");

            migrationBuilder.DropTable(
                name: "DingTalkWokerflowLog");

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
    }
}
