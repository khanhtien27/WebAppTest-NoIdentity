using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTest.Migrations
{
    /// <inheritdoc />
    public partial class Editdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maneger = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDepartment = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSet_DepartmentSet_IdDepartment",
                        column: x => x.IdDepartment,
                        principalTable: "DepartmentSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployment = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreakStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BreakEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetSet_EmployeeSet_IdEmployment",
                        column: x => x.IdEmployment,
                        principalTable: "EmployeeSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSet_IdDepartment",
                table: "EmployeeSet",
                column: "IdDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetSet_IdEmployment",
                table: "TimeSheetSet",
                column: "IdEmployment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSheetSet");

            migrationBuilder.DropTable(
                name: "EmployeeSet");

            migrationBuilder.DropTable(
                name: "DepartmentSet");
        }
    }
}
