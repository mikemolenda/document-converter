namespace DocumentConverter.App.Models;

public class Document
{
    public enum DocumentType
    {
        PDF,
        DOCX,
        TXT
    }

    public Guid Id { get; set; }
    public DocumentType Type { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Document other)
        {
            return Id.Equals(other.Id);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
