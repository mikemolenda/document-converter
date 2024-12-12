using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentConverter.App.Models;

public class User
{
    [Column("id")]
    [Key]
    public Guid Id { get; set; }

    [Column("upload_limit")]
    public int UploadLimit { get; set; } = 0;

    [Column("download_limit")]
    public int DownloadLimit { get; set; } = 0;

    [Column("file_size_limit")]
    public int FileSizeLimit { get; set; } = 0;

    public virtual HashSet<Document>? Documents { get; set; }

}
