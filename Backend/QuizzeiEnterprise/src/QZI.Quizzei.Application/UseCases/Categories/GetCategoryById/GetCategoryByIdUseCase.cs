using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Interfaces;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Models.Request;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Categories.GetCategoryById;

public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryByIdResponse> ExecuteAsync(GetCategoryByIdRequest request)
    {
        var category = await _categoryRepository.GetCategoryById(request.Id);

        if (category == null)
            throw new GenericException("Category not found !");

        return new GetCategoryByIdResponse { Id = category.Id, Description = category.Description };
    }
}