using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Models.Response;

public class GetAllQuestionsCategoriesResponse
{
    public IList<QuestionCategoryResponse> Categories { get; set; } = new List<QuestionCategoryResponse>();

    public GetAllQuestionsCategoriesResponse(IEnumerable<Category> quizCategories)
    {
        foreach (var quizCategory in quizCategories)
        {
            Categories.Add(new QuestionCategoryResponse(quizCategory.Id, quizCategory.Description));
        }
    }
}