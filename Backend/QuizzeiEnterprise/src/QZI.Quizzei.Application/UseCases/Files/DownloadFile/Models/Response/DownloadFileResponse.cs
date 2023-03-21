namespace QZI.Quizzei.Application.UseCases.Files.DownloadFile.Models.Response;

public class DownloadFileResponse
{
    public Stream FileStream { get; set; } = null!;
    public string FileName { get; set; } = null!;

    public static DownloadFileResponse Create(Stream fileStream, string fileName) 
        => new()
        {
            FileName = fileName,
            FileStream = fileStream
        };
}