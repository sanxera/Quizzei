namespace QZI.Quizzei.Application.UseCases.Files.UploadImage.Models.Response;

public class UploadImageResponse
{
    public Guid QuestionImageUuid { get; set; }
    public string ImageName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public static UploadImageResponse Create(Guid imageCreatedUuid, string imageName, string imageUrl) =>
        new()
        {
            QuestionImageUuid = imageCreatedUuid,
            ImageName = imageName,
            ImageUrl = imageUrl
        };
}