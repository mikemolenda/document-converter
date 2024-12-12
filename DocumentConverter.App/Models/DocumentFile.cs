using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentConverter.App.Models;

public class DocumentFile
{
    public enum FileFormat
    {
        PDF,
        DOCX,
        TXT
    }

    [Column("id")]
    [Key]
    public Guid Id { get; set; }

    [Column("format", TypeName = "varchar(10)")]
    public FileFormat Format { get; set; }

    [Column("size")]
    public long Size { get; set; }

    [Column("document_id")]
    public required Guid DocumentId { get; set; }

    public virtual List<DocumentFileProcessingState> ProcessingStates { get; set; } = new List<DocumentFileProcessingState>();

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