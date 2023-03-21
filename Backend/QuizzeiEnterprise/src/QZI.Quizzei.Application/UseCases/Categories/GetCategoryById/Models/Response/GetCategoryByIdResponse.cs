namespace QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Models.Response;

public class GetCategoryByIdResponse
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
}