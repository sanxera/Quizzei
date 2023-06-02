using QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Interfaces;

public interface ICreateCategoryUseCase
{
    Task<CreateCategoryResponse> ExecuteAsync(CreateCategoryRequest request);
}