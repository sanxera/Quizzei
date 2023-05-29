using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory;

public class CreateQuestionCategoryUseCase : ICreateQuestionCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQuestionCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateQuestionCategoryResponse> ExecuteAsync(CreateQuestionCategoryRequest request)
    {
        var newCategory = Category.CreateQuizCategory(request.Name);

        await _categoryRepository.AddAsync(newCategory);
        await _unitOfWork.SaveChangesAsync();

        return new CreateQuestionCategoryResponse { CreatedId = newCategory.Id };
    }
}