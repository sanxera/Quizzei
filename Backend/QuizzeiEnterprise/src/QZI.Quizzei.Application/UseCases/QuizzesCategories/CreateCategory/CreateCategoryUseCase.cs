using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesCategories.CreateCategory;

public class CreateCategoryUseCase : ICreateCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCategoryResponse> ExecuteAsync(CreateCategoryRequest request)
    {
        var newCategory = Category.CreateQuizCategory(request.Name);

        await _categoryRepository.AddAsync(newCategory);
        await _unitOfWork.SaveChangesAsync();

        return new CreateCategoryResponse { CreatedId = newCategory.Id };
    }
}