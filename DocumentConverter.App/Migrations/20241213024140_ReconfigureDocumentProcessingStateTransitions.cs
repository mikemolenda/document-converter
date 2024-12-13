using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DocumentConverter.App.Migrations
{
    /// <inheritdoc />
    public partial class ReconfigureDocumentProcessingStateTransitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_document_file_processing_states_document_files_document_fil~",
                table: "document_file_processing_states");

            migrationBuilder.DropTable(
                name: "document_processing_states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_document_file_processing_states",
                table: "document_file_processing_states");

            migrationBuilder.DropIndex(
                name: "IX_document_file_processing_states_document_file_id",
                table: "document_file_processing_states");

            migrationBuilder.RenameTable(
                name: "document_file_processing_states",
                newName: "DocumentFileProcessingStates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentFileProcessingStates",
                table: "DocumentFileProcessingStates",
                column: "id");

            migrationBuilder.CreateTable(
                name: "document_file_processing_state_transitions",
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
                    table.PrimaryKey("PK_document_file_processing_state_transitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_file_processing_state_transitions_document_files_d~",
                        column: x => x.document_file_id,
                        principalTable: "document_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "document_processing_state_transitions",
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
                    table.PrimaryKey("PK_document_processing_state_transitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_processing_state_transitions_documents_document_id",
                        column: x => x.document_id,
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_document_file_processing_state_transitions_document_file_id",
                table: "document_file_processing_state_transitions",
                column: "document_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_document_processing_state_transitions_document_id",
                table: "document_processing_state_transitions",
                column: "document_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document_file_processing_state_transitions");

            migrationBuilder.DropTable(
                name: "document_processing_state_transitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentFileProcessingStates",
                table: "DocumentFileProcessingStates");

            migrationBuilder.RenameTable(
                name: "DocumentFileProcessingStates",
                newName: "document_file_processing_states");

            migrationBuilder.AddPrimaryKey(
                name: "PK_document_file_processing_states",
                table: "document_file_processing_states",
                column: "id");

            migrationBuilder.CreateTable(
                name: "document_processing_states",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    document_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_state = table.Column<string>(type: "varchar(100)", nullable: false),
                    to_state = table.Column<string>(type: "varchar(100)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_document_file_processing_states_document_files_document_fil~",
                table: "document_file_processing_states",
                column: "document_file_id",
                principalTable: "document_files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
