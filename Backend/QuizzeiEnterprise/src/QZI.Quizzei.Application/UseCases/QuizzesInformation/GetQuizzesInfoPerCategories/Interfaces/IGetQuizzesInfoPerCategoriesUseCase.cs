using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Interfaces;

public interface IGetQuizzesInfoPerCategoriesUseCase
{
    Task<GetQuizzesByCategoryResponse> ExecuteAsync(GetQuizzesInfoPerCategoriesRequest request);
}