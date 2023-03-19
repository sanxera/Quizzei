using System;
using System.Linq;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Process;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services;

public class QuizProcessService : IQuizProcessService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuizProcessRepository _quizProcessRepository;
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuizRateRepository _quizRateRepository;
    private readonly IUserService _userService;

    public QuizProcessService(IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository, IUserService userService, IQuizInfoRepository quizInfoRepository, IQuestionRepository questionRepository, IQuizRateRepository quizRateRepository)
    {
        _unitOfWork = unitOfWork;
        _quizProcessRepository = quizProcessRepository;
        _userService = userService;
        _quizInfoRepository = quizInfoRepository;
        _questionRepository = questionRepository;
        _quizRateRepository = quizRateRepository;
    }

    public async Task<StartQuizProcessResponse> StartQuizProcess(string emailOwner, Guid quizInfoUuid)
    {
        var userResponse = await _userService.GetUserByEmail(emailOwner);
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizInfoUuid);

        await ValidateQuizQuestions(quizInfo.QuizInfoUuid);

        var quizProcess = QuizProcess.CreateQuizProcess(quizInfo.QuizInfoUuid, userResponse.Id);
        await _quizProcessRepository.AddAsync(quizProcess);

        await _unitOfWork.SaveChangesAsync();

        return new StartQuizProcessResponse { QuizProcessCreatedUuid = quizProcess.QuizProcessUuid };
    }

    public async Task<bool> RatingQuiz(Guid quizProcessUuid, int ratePoints)
    {
        var quizProcess = await _quizProcessRepository.GetQuizProcessById(quizProcessUuid);
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizProcess.QuizInfoUuid);

        var rate = QuizRate.CreateQuizRate(quizProcessUuid, quizInfo.QuizInfoUuid, ratePoints);

        await _quizRateRepository.AddAsync(rate);

        await _unitOfWork.SaveChangesAsync();

        var newQuizRate = await CalculateNewRate(quizInfo.QuizInfoUuid);
        quizInfo.UpdateQuizRate(newQuizRate);

        _quizInfoRepository.Update(quizInfo);

        await _unitOfWork.SaveChangesAsync();       
        return true;
    }

    private async Task<int> CalculateNewRate(Guid quizInformationUuid)
    {
        var rates = await _quizRateRepository.GetRatesFromQuizInformation(quizInformationUuid);

        var newAvg = rates.Select(x => x.Rate).Average();

        return Convert.ToInt32(newAvg);
    }

    private async Task ValidateQuizQuestions(Guid quizInfoUuid)
    {
        var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfoUuid);

        if (questions.Count == 0) throw new GenericException("This quiz has no questions !");
    }
}