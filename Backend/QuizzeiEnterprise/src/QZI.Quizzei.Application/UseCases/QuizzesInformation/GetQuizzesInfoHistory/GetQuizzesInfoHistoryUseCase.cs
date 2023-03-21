using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Interfaces;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Images.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Response;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Models.Response;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Models.Request;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory;

public class GetQuizzesInfoHistoryUseCase : IGetQuizzesInfoHistoryUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuizProcessRepository _quizProcessRepository;
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuizRateRepository _quizRateRepository;
    private readonly IImageService _imageService;
    private readonly IUserService _userService;

    public GetQuizzesInfoHistoryUseCase(IUserService userService, IQuizInfoRepository quizInfoRepository, IQuizProcessRepository quizProcessRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IQuestionRepository questionRepository, IAnswerRepository answerRepository, IQuizRateRepository quizRateRepository, IImageService imageService)
    {
        _userService = userService;
        _quizInfoRepository = quizInfoRepository;
        _quizProcessRepository = quizProcessRepository;
        _categoryRepository = categoryRepository;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _quizRateRepository = quizRateRepository;
        _imageService = imageService;
    }

    public async Task<GetQuizzesInfoHistoryResponse> ExecuteAsync(GetQuizzesInfoHistoryRequest request)
    {
        var user = await _userService.GetUserAsync(request.Email);

        var quizzesProcess = await _quizProcessRepository.GetQuizProcessByUser(user.UserUuid);
        await GetQuizInformationByProcess(quizzesProcess);

        return await CreateQuizzesHistoryResponse(quizzesProcess, user);
    }

    private async Task GetQuizInformationByProcess(IEnumerable<QuizProcess> quizzesProcess)
    {
        foreach (var quizProcess in quizzesProcess)
        {
            quizProcess.QuizInformation = await _quizInfoRepository.GetQuizInfoById(quizProcess.QuizInfoUuid);
        }
    }

    private async Task<GetQuizzesInfoHistoryResponse> CreateQuizzesHistoryResponse(IEnumerable<QuizProcess> quizProcesses, GetUserResponse user)
    {
        var response = new GetQuizzesInfoHistoryResponse
        {
            UserUuid = user.UserUuid
        };

        foreach (var quizProcess in quizProcesses)
        {
            var category = await _categoryRepository.GetCategoryById(quizProcess.QuizInformation.CategoryId);
            var questions = await _questionRepository.GetQuestionsByQuizInfo(quizProcess.QuizInformation.QuizInfoUuid);
            var correctAnswers = _answerRepository.GetCorrectAnswersCountByQuizProcess(quizProcess.QuizProcessUuid);
            var quizRate = await _quizRateRepository.GetRateFromQuizProcess(quizProcess.QuizProcessUuid);

            response.QuizzesHistoryInformation.Add(new QuizHistoryInformation
            {
                Title = quizProcess.QuizInformation.Title,
                Description = quizProcess.QuizInformation.Description,
                CategoryDescription = category.Description,
                QuizInfoUuid = quizProcess.QuizInformation.QuizInfoUuid,
                NumberOfQuestions = questions.Count,
                CorrectAnswers = correctAnswers,
                Rate = quizRate,
                OwnerNickName = user.NickName,
                ImageUrl = await _imageService.GetPrefixedImagesUrl(quizProcess.QuizInformation.ImageName)
            });
        }

        return response;
    }
}