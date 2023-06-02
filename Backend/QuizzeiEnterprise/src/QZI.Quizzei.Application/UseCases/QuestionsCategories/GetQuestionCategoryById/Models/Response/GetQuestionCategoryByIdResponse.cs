namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Response;

public class GetQuestionCategoryByIdResponse
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
}