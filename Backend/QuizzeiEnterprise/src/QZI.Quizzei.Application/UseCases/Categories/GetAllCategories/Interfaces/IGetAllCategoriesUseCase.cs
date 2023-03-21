using QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Interfaces;

public interface IGetAllCategoriesUseCase
{
    Task<GetAllCategoriesResponse> ExecuteAsync();
}