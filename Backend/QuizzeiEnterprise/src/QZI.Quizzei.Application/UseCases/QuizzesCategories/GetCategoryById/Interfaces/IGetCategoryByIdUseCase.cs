using QZI.Quizzei.Application.UseCases.QuizzesCategories.GetCategoryById.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesCategories.GetCategoryById.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesCategories.GetCategoryById.Interfaces;

public interface IGetCategoryByIdUseCase
{
    Task<GetCategoryByIdResponse> ExecuteAsync(GetCategoryByIdRequest request);
}