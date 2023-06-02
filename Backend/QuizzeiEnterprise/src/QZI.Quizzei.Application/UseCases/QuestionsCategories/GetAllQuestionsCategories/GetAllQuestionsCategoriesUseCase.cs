using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories;

public class GetAllQuestionsCategoriesUseCase : IGetAllQuestionsCategoriesUseCase
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;

    public GetAllQuestionsCategoriesUseCase(IQuestionCategoryRepository questionCategoryRepository)
    {
        _questionCategoryRepository = questionCategoryRepository;
    }

    public async Task<GetAllQuestionsCategoriesResponse> ExecuteAsync()
    {
        var questionCategories = await _questionCategoryRepository.GetAllQuestionsCategories();
        return new GetAllQuestionsCategoriesResponse(questionCategories);
    }
}