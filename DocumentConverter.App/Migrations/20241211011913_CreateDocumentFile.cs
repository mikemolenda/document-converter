using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentConverter.App.Migrations
{
    /// <inheritdoc />
    public partial class CreateDocumentFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DocumentFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFile_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFile_DocumentId",
                table: "DocumentFile",
                column: "DocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentFile");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Documents",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
