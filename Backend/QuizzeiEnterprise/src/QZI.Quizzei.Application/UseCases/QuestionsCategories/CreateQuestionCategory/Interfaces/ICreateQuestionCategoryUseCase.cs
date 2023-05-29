using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Interfaces;

public interface ICreateQuestionCategoryUseCase
{
    Task<CreateQuestionCategoryResponse> ExecuteAsync(CreateQuestionCategoryRequest request);
}