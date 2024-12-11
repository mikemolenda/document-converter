namespace DocumentConverter.App.Models;

public class Document
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual HashSet<DocumentFile>? Files { get; set; }

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
