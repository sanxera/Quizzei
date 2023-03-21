using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Models.Response;

public class GetAllCategoriesResponse
{
    public IList<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

    public GetAllCategoriesResponse(IEnumerable<Category> quizCategories)
    {
        foreach (var quizCategory in quizCategories)
        {
            Categories.Add(new CategoryResponse(quizCategory.Id, quizCategory.Description));
        }
    }
}