using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DocumentConverter.App.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentProcessingStates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "document_files");

            migrationBuilder.CreateTable(
                name: "document_file_processing_states",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_file_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_state = table.Column<string>(type: "varchar(100)", nullable: false),
                    to_state = table.Column<string>(type: "varchar(100)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_file_processing_states", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_file_processing_states_document_files_document_fil~",
                        column: x => x.document_file_id,
                        principalTable: "document_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "document_processing_states",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_state = table.Column<string>(type: "varchar(100)", nullable: false),
                    to_state = table.Column<string>(type: "varchar(100)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_processing_states", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_processing_states_documents_document_id",
                        column: x => x.document_id,
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_document_file_processing_states_document_file_id",
                table: "document_file_processing_states",
                column: "document_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_document_processing_states_document_id",
                table: "document_processing_states",
                column: "document_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document_file_processing_states");

            migrationBuilder.DropTable(
                name: "document_processing_states");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_at",
                table: "document_files",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
