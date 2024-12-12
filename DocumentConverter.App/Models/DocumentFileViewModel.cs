namespace DocumentConverter.App.Models;

public class DocumentFileViewModel
{
    public string Id { get; set; }
    public string Format { get; set; }
    public long Size { get; set; }

    public DocumentFileViewModel(DocumentFile file)
    {
        Id = file.Id.ToString();
        Format = file.Format.ToString();
        Size = file.Size;
    }
}
