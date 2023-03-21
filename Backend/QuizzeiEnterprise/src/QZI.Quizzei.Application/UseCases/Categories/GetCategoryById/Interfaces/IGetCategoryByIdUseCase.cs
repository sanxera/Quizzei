using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Models.Request;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Interfaces;

public interface IGetCategoryByIdUseCase
{
    Task<GetCategoryByIdResponse> ExecuteAsync(GetCategoryByIdRequest request);
}