using DocumentConverter.App.Models;

namespace DocumentConverter.App.Services;

public interface IDocumentService
{
    Task<Document> GetDocumentByIdAsync(Guid id);
    Task<IEnumerable<Document>> GetAllDocumentsAsync();
    Task<IEnumerable<Document>> GetDocumentsByUserIdAsync(Guid userId);
    Task CreateDocumentAsync(Document document);
}