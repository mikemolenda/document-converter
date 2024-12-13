using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DocumentConverter.App.Models;

namespace DocumentConverter.App.Models;

public class Document
{

    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    public virtual List<DocumentProcessingStateTransition> ProcessingStateTransitions { get; set; } = new List<DocumentProcessingStateTransition>();

    public virtual HashSet<DocumentFile> Files { get; set; } = new HashSet<DocumentFile>();

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

    public override string ToString()
    {
        return $"Document: {Name} ({Id})";
    }
}
