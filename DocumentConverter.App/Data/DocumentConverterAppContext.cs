using Microsoft.EntityFrameworkCore;
using DocumentConverter.App.Models;

namespace DocumentConverter.App.Data;

public class DocumentConverterAppContext : DbContext
{
    public DocumentConverterAppContext(DbContextOptions<DocumentConverterAppContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentFile> DocumentFiles { get; set; }
    public DbSet<DocumentProcessingState> DocumentProcessingStates { get; set; }
    public DbSet<DocumentFileProcessingState> DocumentFileProcessingStates { get; set; }

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
            .HasMany(d => d.ProcessingStates)
            .WithOne()
            .HasForeignKey("DocumentId");

        modelBuilder.Entity<DocumentFile>()
            .ToTable("document_files")
            .HasMany(df => df.ProcessingStates)
            .WithOne()
            .HasForeignKey("DocumentFileId");

        modelBuilder.Entity<DocumentProcessingState>()
            .ToTable("document_processing_states");

        modelBuilder.Entity<DocumentFileProcessingState>()
            .ToTable("document_file_processing_states");
    }
}
