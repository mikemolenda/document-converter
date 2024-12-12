using Microsoft.EntityFrameworkCore;
using DocumentConverter.App.Data;
using DocumentConverter.App.Models;

namespace DocumentConverter.App.Configuration;

public static class DbConfig
{
    // Run database migrations.
    public static void RunMigrations(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DocumentConverterAppContext>();
            context.Database.Migrate();
        }
    }

    // Seed the database with default data.
    public static void SeedDatabase(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DocumentConverterAppContext>();
            context.Database.EnsureCreated();

            // Add file for default document
            if (!context.DocumentFiles.Any())
            {
                context.DocumentFiles.Add(
                    new DocumentFile
                    {
                        Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                        Format = DocumentFile.FileFormat.TXT,
                        Size = 1 * 1024,
                        DocumentId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff")
                    }
                );
            }

            // Add document for default user
            if (!context.Documents.Any())
            {
                context.Documents.Add(
                    new Document
                    {
                        Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                        Name = "Sample Document",
                        UserId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff")
                    }
                );
            }

            // Add default user
            if (!context.Users.Any())
            {
                context.Users.Add(
                    new User
                    {
                        Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                        UploadLimit = 1000,
                        DownloadLimit = 1000,
                        FileSizeLimit = 1 * 1024 * 1024 // 1 MB
                    }
                );
            }

            context.SaveChanges(); 
        }
    }
}