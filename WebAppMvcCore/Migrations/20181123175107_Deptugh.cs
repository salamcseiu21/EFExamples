using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMvcCore.Migrations
{
    public partial class Deptugh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Departments",
                table: "Departments",
                newName: "DeptName");

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "DeptName",
                table: "Departments",
                newName: "Departments");
        }
    }
}
