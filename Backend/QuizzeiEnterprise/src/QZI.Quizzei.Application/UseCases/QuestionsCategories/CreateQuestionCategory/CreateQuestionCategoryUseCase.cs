using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.CreateQuestionCategory;

public class CreateQuestionCategoryUseCase : ICreateQuestionCategoryUseCase
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQuestionCategoryUseCase(IQuestionCategoryRepository questionCategoryRepository, IUnitOfWork unitOfWork)
    {
        _questionCategoryRepository = questionCategoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateQuestionCategoryResponse> ExecuteAsync(CreateQuestionCategoryRequest request)
    {
        var questionCategory = QuestionCategory.CreateQuestionCategory(request.Name);

        await _questionCategoryRepository.AddAsync(questionCategory);
        await _unitOfWork.SaveChangesAsync();

        return new CreateQuestionCategoryResponse { CreatedId = questionCategory.Id };
    }
}