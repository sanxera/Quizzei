using QZI.Quizzei.Application.UseCases.QuizzesCategories.GetAllCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesCategories.GetAllCategories.Interfaces;

public interface IGetAllCategoriesUseCase
{
    Task<GetAllCategoriesResponse> ExecuteAsync();
}