using Microsoft.EntityFrameworkCore;
using DocumentConverter.App.Models;

namespace DocumentConverter.App.Data;

public class DocumentConverterAppContext : DbContext
{
    public DocumentConverterAppContext(DbContextOptions<DocumentConverterAppContext> options) : base(options)
    {
    }

    public required DbSet<User> Users { get; set; }
    public required DbSet<Document> Documents { get; set; }
    public required DbSet<DocumentFile> DocumentFiles { get; set; }
    public required DbSet<DocumentProcessingStateTransition> DocumentProcessingStateTransitions { get; set; }
    public required DbSet<DocumentFileProcessingStateTransition> DocumentFileProcessingStateTransitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .ToTable("users")
            .HasMany(u => u.Documents)
            .WithOne()
            .HasForeignKey("UserId");

        modelBuilder.Entity<Document>()
            .ToTable("documents")
            .HasMany(d => d.Files)
            .WithOne()
            .HasForeignKey("DocumentId");

        modelBuilder.Entity<Document>()
            .HasMany(d => d.ProcessingStateTransitions)
            .WithOne()
            .HasForeignKey("DocumentId");

        modelBuilder.Entity<DocumentFile>()
            .ToTable("document_files")
            .HasMany(df => df.ProcessingStateTransitions)
            .WithOne()
            .HasForeignKey("DocumentFileId");

        modelBuilder.Entity<DocumentProcessingStateTransition>()
            .ToTable("document_processing_state_transitions");

        modelBuilder.Entity<DocumentFileProcessingStateTransition>()
            .ToTable("document_file_processing_state_transitions");
    }
}