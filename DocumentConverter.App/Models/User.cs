namespace DocumentConverter.App.Models;

public class User
{
    public Guid UserId { get; set; }

    public int UploadLimit { get; set; } = 0;

    public int DownloadLimit { get; set; } = 0;

    public int FileSizeLimit { get; set; } = 0;

    public virtual HashSet<Document>? Documents { get; set; }

}
