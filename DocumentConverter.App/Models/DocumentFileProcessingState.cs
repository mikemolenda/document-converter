using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentConverter.App.Models;

public class DocumentFileProcessingState
{
    [Column("id")]
    [Key]
    public long Id { get; set; }

    [Column("document_file_id")]
    public Guid DocumentFileId { get; set; }

    [Column("from_state", TypeName = "varchar(100)")]
    public required ProcessingState FromState { get; set; }

    [Column("to_state", TypeName = "varchar(100)")]
    public required ProcessingState ToState { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}