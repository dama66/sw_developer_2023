using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.TimeManager.Model.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[LastName] + ' ' + [FirstName]", stored: true),
                    Email = table.Column<string>(type: "nVarchar(100)", maxLength: 100, nullable: false),
                    EntryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExitDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TimeRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRecord", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_TimeRecord_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeRecord_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeRecord_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_lastname",
                table: "Person",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "idx_projectname",
                table: "Project",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_taskname",
                table: "Task",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_taskname",
                table: "TimeRecord",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecord_PersonId",
                table: "TimeRecord",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecord_ProjectId",
                table: "TimeRecord",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecord_TaskId",
                table: "TimeRecord",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeRecord");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
