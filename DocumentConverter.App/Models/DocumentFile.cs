namespace DocumentConverter.App.Models;

public class DocumentFile
{
    public enum FileFormat
    {
        PDF,
        DOCX,
        TXT
    }

    public Guid Id { get; set; }
    public FileFormat Format { get; set; }
    public long Size { get; set; }
    public DateTime CreatedAt { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is DocumentFile other)
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