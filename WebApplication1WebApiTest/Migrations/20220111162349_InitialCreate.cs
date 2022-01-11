using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1WebApiTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departmentsprop",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentsprop", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employeeprop",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBrith = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeeprop", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employeeprop_departmentsprop_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departmentsprop",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departmentsprop",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "PayRoll" },
                    { 4, "Staffing" }
                });

            migrationBuilder.InsertData(
                table: "Employeeprop",
                columns: new[] { "EmployeeId", "DateOfBrith", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[] { 101, new DateTime(2000, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "sara@gmail.com", "Sara", 1, "Tondon", "~/wwwroot/Images/Flower1.jpg" });

            migrationBuilder.InsertData(
                table: "Employeeprop",
                columns: new[] { "EmployeeId", "DateOfBrith", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[] { 102, new DateTime(2001, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "John@gmail.com", "John", 0, "Srikant", "~/wwwroot/Images/Flower2.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Employeeprop_DepartmentId",
                table: "Employeeprop",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeeprop");

            migrationBuilder.DropTable(
                name: "departmentsprop");
        }
    }
}
