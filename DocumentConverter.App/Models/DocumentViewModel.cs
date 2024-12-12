namespace DocumentConverter.App.Models;

public class DocumentViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<DocumentFileViewModel> Files { get; set; }

    public DocumentViewModel(Document document)
    {
        Id = document.Id.ToString();
        Name = document.Name;
        Files = document.Files?.Select(f => new DocumentFileViewModel(f)).ToList() ?? new List<DocumentFileViewModel>();
    }
}
