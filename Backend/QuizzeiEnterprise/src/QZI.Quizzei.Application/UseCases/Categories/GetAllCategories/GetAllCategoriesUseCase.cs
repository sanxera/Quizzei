using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Interfaces;
using QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Categories.GetAllCategories;

public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetAllCategoriesResponse> ExecuteAsync()
    {
        var categories = await _categoryRepository.GetAllCategories();
        return new GetAllCategoriesResponse(categories);
    }
}