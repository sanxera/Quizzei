namespace QZI.Quizzei.Application.UseCases.Files.UploadFile.Models.Request;

public class UploadFileRequest
{
    public Guid QuizInfoUuid { get; set; }
    public string FileName { get; set; } = null!;
    public Stream FileStream { get; set; } = null!;
}