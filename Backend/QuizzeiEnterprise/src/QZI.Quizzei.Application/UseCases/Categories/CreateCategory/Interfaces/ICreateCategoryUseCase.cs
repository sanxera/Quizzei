using QZI.Quizzei.Application.UseCases.Categories.CreateCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.Categories.CreateCategory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Categories.CreateCategory.Interfaces;

public interface ICreateCategoryUseCase
{
    Task<CreateCategoryResponse> ExecuteAsync(CreateCategoryRequest request);
}