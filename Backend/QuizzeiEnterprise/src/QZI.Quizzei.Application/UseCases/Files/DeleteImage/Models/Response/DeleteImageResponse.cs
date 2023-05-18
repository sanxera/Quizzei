namespace QZI.Quizzei.Application.UseCases.Files.DeleteImage.Models.Response;

public class DeleteImageResponse
{
    private DeleteImageResponse(bool deleted)
    {
        Deleted = deleted;
    }

    public bool Deleted { get; set; }

    public static DeleteImageResponse Create(bool deleted) => new DeleteImageResponse(deleted);
}