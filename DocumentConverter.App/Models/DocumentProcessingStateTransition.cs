using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentConverter.App.Models;

public class DocumentProcessingStateTransition: ProcessingStateTransition
{
    [Column("document_id")]
    public Guid DocumentId { get; set; }
}