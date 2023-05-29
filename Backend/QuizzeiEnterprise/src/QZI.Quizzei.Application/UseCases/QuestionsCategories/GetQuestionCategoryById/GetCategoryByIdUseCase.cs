using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Request;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById;

public class GetQuestionCategoryByIdUseCase : IGetQuestionCategoryByIdUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public GetQuestionCategoryByIdUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetQuestionCategoryByIdResponse> ExecuteAsync(GetQuestionCategoryByIdRequest request)
    {
        var category = await _categoryRepository.GetCategoryById(request.Id);

        if (category == null)
            throw new GenericException("Category not found !");

        return new GetQuestionCategoryByIdResponse { Id = category.Id, Description = category.Description };
    }
}