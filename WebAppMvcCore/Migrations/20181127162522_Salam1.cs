using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMvcCore.Migrations
{
    public partial class Salam1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentsId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentsId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentsId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Courses",
                newName: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Courses",
                newName: "DeptId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentsId",
                table: "Courses",
                column: "DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentsId",
                table: "Courses",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
