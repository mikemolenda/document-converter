using System.Diagnostics;
using DocumentConverter.App.Models;
using DocumentConverter.App.Utilities;

namespace DocumentConverter.App.Services;

public class DocumentProcessingService : IDocumentProcessingService
{
    private readonly IDocumentService _documentService;
    private readonly IDocumentFileService _documentFileService;

    public DocumentProcessingService(IDocumentService documentService, IDocumentFileService documentFileService)
    {
        _documentService = documentService;
        _documentFileService = documentFileService;
    }

    public async Task ProcessNewDocumentAsync(Guid userId, IFormFile file)
    {

        // TODO check upload limits

        // TODO handle exception
        var fileFormat = file.GetDocumentFileFormat();

        // Create new document and file records
        var document = new Document
        {
            Name = file.FileName,
            UserId = userId
        };

        var documentFile = new DocumentFile
        {
            Format = fileFormat,
            Size = file.Length,
            DocumentId = document.Id,
        };

        // TODO file state transition new -> uploaded
        // TODO document state transition new -> processing

        document.Files.Add(documentFile);

        await _documentService.CreateDocumentAsync(document);

        // TODO Set document state to Processing
        // TODO Set file state to Uploaded
        // TODO Determine other formats for conversion - from hashset? or table?
        // TODO Set file state to Saving
        // TODO Save file to S3 async
        // TODO Await S3 response and set file state to Saved
        // TODO create new file records for each conversion format and set state to Converting
        // TODO Convert document to other formats async
        // TODO Await conversion response and set file state to Converted
        // TODO Write each file to S3 async
        // TODO Await S3 response and set file state to Saved
        // TODO Set document state to Success
    }
}