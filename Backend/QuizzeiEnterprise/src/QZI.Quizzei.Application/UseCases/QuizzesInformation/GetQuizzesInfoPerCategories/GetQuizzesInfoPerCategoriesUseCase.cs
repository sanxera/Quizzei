using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Interfaces;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Images.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories;

public class GetQuizzesInfoPerCategoriesUseCase : IGetQuizzesInfoPerCategoriesUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IImageService _imageService;
    private readonly IUserService _userService;

    public GetQuizzesInfoPerCategoriesUseCase(IQuizInfoRepository quizInfoRepository, ICategoryRepository categoryRepository, IQuestionRepository questionRepository, IImageService imageService, IUserService userService)
    {
        _quizInfoRepository = quizInfoRepository;
        _categoryRepository = categoryRepository;
        _questionRepository = questionRepository;
        _imageService = imageService;
        _userService = userService;
    }

    public async Task<GetQuizzesByCategoryResponse> ExecuteAsync()
    {
        var response = new GetQuizzesByCategoryResponse();
        var categories = await _categoryRepository.GetCategoriesInRange(5);

        foreach (var category in categories)
        {
            var quizzesByCategory = await _quizInfoRepository.GetQuizzesByCategory(category.Id);
            var quizzesByCategoryResponse = new QuizzesByCategory { CategoryName = category.Description };

            await CreateQuizzesResponsePerCategory(quizzesByCategory, category, quizzesByCategoryResponse);

            response.QuizzesByCategories.Add(quizzesByCategoryResponse);
        }

        return response;
    }

    private async Task CreateQuizzesResponsePerCategory(IEnumerable<QuizInformation> quizzesByCategory, Category category, QuizzesByCategory quizzesByCategoryResponse)
    {
        foreach (var quiz in quizzesByCategory)
        {
            var questions = await _questionRepository.GetQuestionsByQuizInfo(quiz.QuizInfoUuid);
            var quizResponse = new QuizInfoResponse
            {
                Title = quiz.Title,
                Description = quiz.Description,
                CategoryDescription = category.Description,
                QuizInfoUuid = quiz.QuizInfoUuid,
                NumberOfQuestions = questions.Count,
                OwnerNickName = await GetUserOwnerNickName(quiz.UserOwnerId),
                ImageUrl = await _imageService.GetPrefixedImagesUrl(quiz.ImageName)
            };

            quizzesByCategoryResponse.QuizzesInfoResponses.Add(quizResponse);
        }
    }

    private async Task<string> GetUserOwnerNickName(Guid userUuid)
    {
        var user = await _userService.GetUserAsync(userUuid);

        return user == null ? "Admin" : user.NickName;
    }
}