using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Models.Request;

namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz;

public class RatingQuizUseCase : IRatingQuizUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuizProcessRepository _quizProcessRepository;
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly IQuizRateRepository _quizRateRepository;

    public RatingQuizUseCase(IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository, IQuizInfoRepository quizInfoRepository, IQuizRateRepository quizRateRepository)
    {
        _unitOfWork = unitOfWork;
        _quizProcessRepository = quizProcessRepository;
        _quizInfoRepository = quizInfoRepository;
        _quizRateRepository = quizRateRepository;
    }

    public async Task ExecuteAsync(RatingQuizRequest request)
    {
        var quizProcess = await _quizProcessRepository.GetQuizProcessById(request.QuizInformationUuid);
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizProcess.QuizInfoUuid);

        var rate = QuizRate.CreateQuizRate(request.QuizInformationUuid, quizInfo.QuizInfoUuid, request.RatePoints);

        await _quizRateRepository.AddAsync(rate);

        var newQuizRate = await CalculateNewRate(quizInfo.QuizInfoUuid) ?? request.RatePoints;

        quizInfo.UpdateQuizRate(newQuizRate);
        _quizInfoRepository.Update(quizInfo);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<int?> CalculateNewRate(Guid quizInformationUuid)
    {
        var rates = await _quizRateRepository.GetRatesFromQuizInformation(quizInformationUuid);

        if (!rates.Any())
            return null;

        var newAvg = rates.Select(x => x.Rate).Average();

        return Convert.ToInt32(newAvg);
    }
}