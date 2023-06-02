using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Request;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetQuestionCategoryById;

public class GetQuestionCategoryByIdUseCase : IGetQuestionCategoryByIdUseCase
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;

    public GetQuestionCategoryByIdUseCase(IQuestionCategoryRepository questionCategoryRepository)
    {
        _questionCategoryRepository = questionCategoryRepository;
    }

    public async Task<GetQuestionCategoryByIdResponse> ExecuteAsync(GetQuestionCategoryByIdRequest request)
    {
        var questionCategory = await _questionCategoryRepository.GetQuestionCategoryById(request.Id);

        if (questionCategory == null)
            throw new GenericException("Question Category not found !");

        return new GetQuestionCategoryByIdResponse { Id = questionCategory.Id, Description = questionCategory.Description };
    }
}