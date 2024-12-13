using DocumentConverter.App.Models;

namespace DocumentConverter.App.Services;

public interface IDocumentFileService
{
    Task CreateDocumentFileAsync(DocumentFile documentFile);
}