namespace QZI.Quizzei.Application.UseCases.Files.UploadImage.Models.Request;

public class UploadImageRequest
{
    public string FileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public Stream FileStream { get; set; } = null!;
}