using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Models.Response;

public class GetAllQuestionsCategoriesResponse
{
    public IList<QuestionCategoryResponse> QuestionsCategories { get; set; } = new List<QuestionCategoryResponse>();

    public GetAllQuestionsCategoriesResponse(IEnumerable<QuestionCategory> quizCategories)
    {
        foreach (var quizCategory in quizCategories)
        {
            QuestionsCategories.Add(new QuestionCategoryResponse(quizCategory.Id, quizCategory.Description));
        }
    }
}