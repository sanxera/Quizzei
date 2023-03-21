using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Interfaces;

public interface IGetQuizzesInfoPerCategoriesUseCase
{
    Task<GetQuizzesByCategoryResponse> ExecuteAsync();
}