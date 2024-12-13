using DocumentConverter.App.Data;
using DocumentConverter.App.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentConverter.App.Services;

public class DocumentService : IDocumentService
{
    private readonly DocumentConverterAppContext _context;

    public DocumentService(DocumentConverterAppContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
    {
        return await _context.Documents
            .Include(d => d.Files)
            .ToListAsync();
    }

    public async Task<Document> GetDocumentByIdAsync(Guid id)
    {
        var document = await _context.Documents
            .Include(d => d.Files)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (document == null)
        {
            throw new KeyNotFoundException($"Document with ID {id} not found.");
        }

        return document;
    }

    public async Task<IEnumerable<Document>> GetDocumentsByUserIdAsync(Guid userId)
    {
        return await _context.Documents
            .Include(d => d.Files)
            .Where(d => d.UserId == userId)
            .ToListAsync();
    }

    public async Task CreateDocumentAsync(Document document)
    {
        await _context.Documents.AddAsync(document);
        await _context.SaveChangesAsync();
    }

}
