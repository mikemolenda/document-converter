using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentConverter.App.Models;

public class DocumentFileProcessingStateTransition: ProcessingStateTransition
{
    [Column("document_file_id")]
    public Guid DocumentFileId { get; set; }
}