namespace QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Models.Response;

public class GetFilesFromQuizInfoResponse
{
    public IList<FileResponse> FilesResponse { get; set; } = new List<FileResponse>();
}

public class FileResponse
{
    public Guid FileCreatedUuid { get; set; }
    public string FileName { get; set; } = null!;

    public static FileResponse Create(Guid fileCreatedUuid, string fileName)
        => new()
        {
            FileCreatedUuid = fileCreatedUuid,
            FileName = fileName
        };
}