using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Request;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Interfaces;

public interface IGetQuestionCategoryByIdUseCase
{
    Task<GetQuestionCategoryByIdResponse> ExecuteAsync(GetQuestionCategoryByIdRequest request);
}