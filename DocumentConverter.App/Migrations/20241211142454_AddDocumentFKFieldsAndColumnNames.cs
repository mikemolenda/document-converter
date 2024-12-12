using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentConverter.App.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentFKFieldsAndColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_document_files_documents_DocumentId",
                table: "document_files");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_users_UserId",
                table: "documents");

            migrationBuilder.RenameColumn(
                name: "UploadLimit",
                table: "users",
                newName: "upload_limit");

            migrationBuilder.RenameColumn(
                name: "FileSizeLimit",
                table: "users",
                newName: "file_size_limit");

            migrationBuilder.RenameColumn(
                name: "DownloadLimit",
                table: "users",
                newName: "download_limit");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "documents",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "documents",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "documents",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_documents_UserId",
                table: "documents",
                newName: "IX_documents_user_id");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "document_files",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Format",
                table: "document_files",
                newName: "format");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "document_files",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "document_files",
                newName: "document_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "document_files",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_document_files_DocumentId",
                table: "document_files",
                newName: "IX_document_files_document_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "document_id",
                table: "document_files",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_document_files_documents_document_id",
                table: "document_files",
                column: "document_id",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_users_user_id",
                table: "documents",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_document_files_documents_document_id",
                table: "document_files");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_users_user_id",
                table: "documents");

            migrationBuilder.RenameColumn(
                name: "upload_limit",
                table: "users",
                newName: "UploadLimit");

            migrationBuilder.RenameColumn(
                name: "file_size_limit",
                table: "users",
                newName: "FileSizeLimit");

            migrationBuilder.RenameColumn(
                name: "download_limit",
                table: "users",
                newName: "DownloadLimit");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "documents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "documents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "documents",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_documents_user_id",
                table: "documents",
                newName: "IX_documents_UserId");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "document_files",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "format",
                table: "document_files",
                newName: "Format");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "document_files",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "document_id",
                table: "document_files",
                newName: "DocumentId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "document_files",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_document_files_document_id",
                table: "document_files",
                newName: "IX_document_files_DocumentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentId",
                table: "document_files",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_document_files_documents_DocumentId",
                table: "document_files",
                column: "DocumentId",
                principalTable: "documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_documents_users_UserId",
                table: "documents",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId");
        }
    }
}
