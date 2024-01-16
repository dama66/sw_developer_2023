using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.TimeManager.Model.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Project",
                type: "nVarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nVarchar(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Project",
                type: "nVarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nVarchar(50)",
                oldNullable: true);
        }
    }
}
