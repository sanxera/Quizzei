using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Interfaces;

public interface IGetAllQuestionsCategoriesUseCase
{
    Task<GetAllQuestionsCategoriesResponse> ExecuteAsync();
}