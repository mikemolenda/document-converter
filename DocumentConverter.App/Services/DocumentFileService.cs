using DocumentConverter.App.Models;
using DocumentConverter.App.Data;

namespace DocumentConverter.App.Services;

public class DocumentFileService : IDocumentFileService
{
    private readonly DocumentConverterAppContext _context;

    public DocumentFileService(DocumentConverterAppContext context)
    {
        _context = context;
    }

    public async Task CreateDocumentFileAsync(DocumentFile documentFile)
    {
        await _context.DocumentFiles.AddAsync(documentFile);
        await _context.SaveChangesAsync();
    }
}