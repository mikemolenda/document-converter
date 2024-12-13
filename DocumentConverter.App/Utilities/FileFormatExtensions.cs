using DocumentConverter.App.Models;

namespace DocumentConverter.App.Utilities;

public static class FileFormatExtensions
{
    public static DocumentFile.FileFormat GetDocumentFileFormat(this IFormFile file)
    {
        return file.ContentType switch
        {
            "application/pdf" => DocumentFile.FileFormat.PDF,
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document" => DocumentFile.FileFormat.DOCX,
            "text/plain" => DocumentFile.FileFormat.TXT,
            _ => throw new ArgumentException($"Unsupported content type: {file.ContentType}")
        };
    }
}