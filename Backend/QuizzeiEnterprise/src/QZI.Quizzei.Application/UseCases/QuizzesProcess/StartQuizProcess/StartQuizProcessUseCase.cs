using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Interfaces;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess;

public class StartQuizProcessUseCase : IStartQuizProcessUseCase
{
    private readonly IQuizProcessRepository _quizProcessRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;

    public StartQuizProcessUseCase(IQuizProcessRepository quizProcessRepository, IQuestionRepository questionRepository, IUnitOfWork unitOfWork, IUserService userService, IQuizInfoRepository quizInfoRepository)
    {
        _quizProcessRepository = quizProcessRepository;
        _questionRepository = questionRepository;
        _unitOfWork = unitOfWork;
        _userService = userService;
        _quizInfoRepository = quizInfoRepository;
    }

    public async Task<StartQuizProcessResponse> ExecuteAsync(StartQuizProcessRequest request)
    {
        var userResponse = await _userService.GetUserAsync(request.EmailOwner);
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(request.QuizUuid);

        ValidateQuizPermission(request, quizInfo);

        await ValidateQuizQuestions(quizInfo.QuizInfoUuid);

        var quizProcess = QuizProcess.Create(quizInfo.QuizInfoUuid, userResponse.UserUuid);
        await _quizProcessRepository.AddAsync(quizProcess);

        await _unitOfWork.SaveChangesAsync();

        return StartQuizProcessResponse.Create(quizProcess.QuizProcessUuid);
    }

    private static void ValidateQuizPermission(StartQuizProcessRequest request, QuizInformation quizInfo)
    {
        if (quizInfo.PermissionType == PermissionType.Pubic) return;

        if (quizInfo.QuizAccess?.AccessCode != request.AccessInformation?.AccessCode)
            throw new GenericException("Access Code is invalid");
    }

    private async Task ValidateQuizQuestions(Guid quizInfoUuid)
    {
        var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfoUuid);

        if (questions.Count == 0) throw new GenericException("This quiz has no questions !");
    }
}