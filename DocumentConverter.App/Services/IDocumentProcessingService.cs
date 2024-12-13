namespace DocumentConverter.App.Services;

public interface IDocumentProcessingService
{
    Task ProcessNewDocumentAsync(Guid userId, IFormFile file);
}