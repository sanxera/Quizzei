namespace QZI.Quizzei.Application.UseCases.Files.UploadFile.Models.Response;

public class UploadFileResponse
{
    public Guid FileCreatedUuid { get; set; }
    public string FileName { get; set; } = null!;

    public static UploadFileResponse Create(Guid fileCreatedUuid, string fileName) =>
        new()
        {
            FileCreatedUuid = fileCreatedUuid,
            FileName = fileName
        };
}