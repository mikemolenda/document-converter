using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentConverter.App.Models;

public class DocumentProcessingState
{

    [Column("id")]
    [Key]
    public long Id { get; set; }

    [Column("document_id")]
    public Guid DocumentId { get; set; }

    [Column("from_state", TypeName = "varchar(100)")]
    public required ProcessingState FromState { get; set; }

    [Column("to_state", TypeName = "varchar(100)")]
    public required ProcessingState ToState { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

}