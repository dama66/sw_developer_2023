using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.Messanger.Model.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageState",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<string>(type: "nVarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageState", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "MessageType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageType", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Sent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sender = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Receiver = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    SentMessage = table.Column<string>(type: "nVarchar(MAX)", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Message_MessageState_StateId",
                        column: x => x.StateId,
                        principalTable: "MessageState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_MessageType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MessageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_StateId",
                table: "Message",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_TypeId",
                table: "Message",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "MessageState");

            migrationBuilder.DropTable(
                name: "MessageType");
        }
    }
}
