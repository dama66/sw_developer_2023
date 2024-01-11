using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.Messanger.Model.Migrations
{
    /// <inheritdoc />
    public partial class AlternateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageState",
                table: "MessageState");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageState",
                table: "MessageState",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageState",
                table: "MessageState");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageState",
                table: "MessageState",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);
        }
    }
}
