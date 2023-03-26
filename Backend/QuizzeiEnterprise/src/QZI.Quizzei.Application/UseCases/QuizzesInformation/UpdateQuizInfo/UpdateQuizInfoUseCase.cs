using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Models.Request;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo;

public class UpdateQuizInfoUseCase : IUpdateQuizInfoUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuizInfoRepository _quizInfoRepository;

    public UpdateQuizInfoUseCase(IQuizInfoRepository quizInfoRepository, IUnitOfWork unitOfWork)
    {
        _quizInfoRepository = quizInfoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(Guid quizInfoUuid, UpdateQuizInfoRequest request)
    {
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizInfoUuid);

        quizInfo.Description = request.Description;
        quizInfo.Title = request.Title;
        quizInfo.CategoryId = request.CategoryId;
        quizInfo.ImageName = request.ImageName;
        quizInfo.PermissionType = request.PermissionType;

        if (request.PermissionType != PermissionType.Pubic)
            CreateQuizAccess(quizInfoUuid, request, quizInfo);
        else
            ExpireQuizAccess(quizInfo);

        _quizInfoRepository.Update(quizInfo);
        await _unitOfWork.SaveChangesAsync();
    }

    private static void CreateQuizAccess(Guid quizInfoUuid, UpdateQuizInfoRequest request, QuizInformation quizInfo)
    {
        quizInfo.QuizAccess ??= QuizAccess.Create(quizInfoUuid, request.QuizAccess!.InitialDate, request.QuizAccess.EndDate,
            request.QuizAccess.AccessCode);
    }

    private static void ExpireQuizAccess(QuizInformation quizInfo)
    {
        if (quizInfo.QuizAccess is not null)
        {
            quizInfo.QuizAccess.EndDate = DateTime.Now;
        }
    }
}