using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMvcCore.Migrations
{
    public partial class Dept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Courses_CourseId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CourseId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Departments");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Departments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CourseId",
                table: "Departments",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Courses_CourseId",
                table: "Departments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
