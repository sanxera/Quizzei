using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Images.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Response;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser;

public class GetQuizzesInfoForUserUseCase : IGetQuizzesInfoForUserUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IImageService _imageService;
    private readonly IUserService _userService;

    public GetQuizzesInfoForUserUseCase(IQuizInfoRepository quizInfoRepository, ICategoryRepository categoryRepository, IQuestionRepository questionRepository, IImageService imageService, IUserService userService)
    {
        _quizInfoRepository = quizInfoRepository;
        _categoryRepository = categoryRepository;
        _questionRepository = questionRepository;
        _imageService = imageService;
        _userService = userService;
    }

    public async Task<GetQuizzesInfoForUserResponse> ExecuteAsync(GetQuizzesInfoForUserRequest request)
    {
        var user = await _userService.GetUserAsync(request.EmailOwner);
        var quizzes = await _quizInfoRepository.GetQuizInfoByDifferentUsers(user.UserUuid);

        var response = await CreateQuizzesResponse(quizzes, user);

        return response;
    }

    private async Task<GetQuizzesInfoForUserResponse> CreateQuizzesResponse(IEnumerable<QuizInformation> quizzes, GetUserResponse user)
    {
        var response = new GetQuizzesInfoForUserResponse();

        foreach (var quiz in quizzes)
        {
            var category = await _categoryRepository.GetCategoryById(quiz.CategoryId);
            var questions = await _questionRepository.GetQuestionsByQuizInfo(quiz.QuizInfoUuid);

            response.QuizzesInfoDto.Add(new QuizInfoResponse
            {
                Title = quiz.Title,
                Description = quiz.Description,
                CategoryDescription = category.Description,
                QuizInfoUuid = quiz.QuizInfoUuid,
                NumberOfQuestions = questions.Count,
                OwnerNickName = user.NickName,
                ImageUrl = await _imageService.GetPrefixedImagesUrl(quiz.ImageName)
            });
        }

        return response;
    }
}