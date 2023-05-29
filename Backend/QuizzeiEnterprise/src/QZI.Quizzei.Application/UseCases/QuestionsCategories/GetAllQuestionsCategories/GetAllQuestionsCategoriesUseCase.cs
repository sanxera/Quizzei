using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Interfaces;
using QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories;

public class GetAllQuestionsCategoriesUseCase : IGetAllQuestionsCategoriesUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllQuestionsCategoriesUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetAllQuestionsCategoriesResponse> ExecuteAsync()
    {
        var categories = await _categoryRepository.GetAllCategories();
        return new GetAllQuestionsCategoriesResponse(categories);
    }
}