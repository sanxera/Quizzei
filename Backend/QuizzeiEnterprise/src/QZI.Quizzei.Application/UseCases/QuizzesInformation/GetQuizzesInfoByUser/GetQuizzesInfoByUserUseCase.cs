using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Models.Response;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Images.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Response;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Models.Request;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser;

public class GetQuizzesInfoByUserUseCase : IGetQuizzesInfoByUserUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IImageService _imageService;
    private readonly IUserService _userService;

    public GetQuizzesInfoByUserUseCase(IQuizInfoRepository quizInfoRepository, ICategoryRepository categoryRepository, IQuestionRepository questionRepository, IImageService imageService, IUserService userService)
    {
        _quizInfoRepository = quizInfoRepository;
        _categoryRepository = categoryRepository;
        _questionRepository = questionRepository;
        _imageService = imageService;
        _userService = userService;
    }

    public async Task<GetQuizzesInfoByUserResponse> ExecuteAsync(GetQuizzesInfoByUserRequest request)
    {
        GetUserResponse user;

        if (request.UserUuid is not null)
            user = await _userService.GetUserAsync(request.UserUuid.Value);
        else
            user = await _userService.GetUserAsync(request.Email!);

        var quizzes = await _quizInfoRepository.GetQuizInfoByUserUuid(user.UserUuid);

        return await CreateQuizzesResponse(quizzes, user);
    }

    private async Task<GetQuizzesInfoByUserResponse> CreateQuizzesResponse(IEnumerable<QuizInformation> quizzes, GetUserResponse user)
    {
        var response = new GetQuizzesInfoByUserResponse();

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
                ImageUrl = await _imageService.GetPrefixedImagesUrl(quiz.ImageName),
                PermissionType = quiz.PermissionType,
                QuizAccess = quiz.QuizAccess == null ? null : new QuizAccessResponse
                {
                    AccessCode = quiz.QuizAccess?.AccessCode,
                    EndDate = quiz.QuizAccess?.EndDate,
                    InitialDate = quiz.QuizAccess?.InitialDate
                }
            });
        }

        return response;
    }
}