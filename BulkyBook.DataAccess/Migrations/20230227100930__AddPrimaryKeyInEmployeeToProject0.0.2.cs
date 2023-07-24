using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    public partial class _AddPrimaryKeyInEmployeeToProject002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeToProject_EmployeeTest_EmployeeId",
                table: "EmployeeToProject");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeToProject_ProjectTest_ProjectId",
                table: "EmployeeToProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTest",
                table: "ProjectTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTest",
                table: "EmployeeTest");

            migrationBuilder.RenameTable(
                name: "ProjectTest",
                newName: "ProjectTests");

            migrationBuilder.RenameTable(
                name: "EmployeeTest",
                newName: "EmployeeTests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTests",
                table: "ProjectTests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTests",
                table: "EmployeeTests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeToProject_EmployeeTests_EmployeeId",
                table: "EmployeeToProject",
                column: "EmployeeId",
                principalTable: "EmployeeTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeToProject_ProjectTests_ProjectId",
                table: "EmployeeToProject",
                column: "ProjectId",
                principalTable: "ProjectTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeToProject_EmployeeTests_EmployeeId",
                table: "EmployeeToProject");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeToProject_ProjectTests_ProjectId",
                table: "EmployeeToProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTests",
                table: "ProjectTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTests",
                table: "EmployeeTests");

            migrationBuilder.RenameTable(
                name: "ProjectTests",
                newName: "ProjectTest");

            migrationBuilder.RenameTable(
                name: "EmployeeTests",
                newName: "EmployeeTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTest",
                table: "ProjectTest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTest",
                table: "EmployeeTest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeToProject_EmployeeTest_EmployeeId",
                table: "EmployeeToProject",
                column: "EmployeeId",
                principalTable: "EmployeeTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeToProject_ProjectTest_ProjectId",
                table: "EmployeeToProject",
                column: "ProjectId",
                principalTable: "ProjectTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
