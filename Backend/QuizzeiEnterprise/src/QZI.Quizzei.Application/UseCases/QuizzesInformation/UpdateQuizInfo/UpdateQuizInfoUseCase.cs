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

        switch (request.PermissionType)
        {
            case PermissionType.Pubic:
                SetPublicQuiz(quizInfo);
                break;
            case PermissionType.Private:
                SetPrivateQuiz(quizInfo, request);
                break;
            case PermissionType.Temporary:
                SetTemporaryQuiz(quizInfo, request);
                break;
        }

        _quizInfoRepository.Update(quizInfo);
        await _unitOfWork.SaveChangesAsync();
    }

    private static void SetTemporaryQuiz(QuizInformation quizInfo, UpdateQuizInfoRequest request)
    {
        if (quizInfo.QuizAccess is null)
        {
            quizInfo.QuizAccess = QuizAccess.Create(quizInfo.QuizInfoUuid, request.QuizAccess!.InitialDate, request.QuizAccess.EndDate, request.QuizAccess.AccessCode);
        }
        else
        {
            quizInfo.QuizAccess.EndDate = request.QuizAccess!.EndDate;
            quizInfo.QuizAccess.InitialDate = request.QuizAccess!.InitialDate;
            quizInfo.QuizAccess.AccessCode = request.QuizAccess!.AccessCode;
        }
    }

    private static void SetPrivateQuiz(QuizInformation quizInfo, UpdateQuizInfoRequest request)
    {
        if (quizInfo.QuizAccess is null)
        {
            quizInfo.QuizAccess = QuizAccess.Create(quizInfo.QuizInfoUuid, null, null, request.QuizAccess!.AccessCode);
        }
        else
        {
            quizInfo.QuizAccess.EndDate = null;
            quizInfo.QuizAccess.InitialDate = null;
            quizInfo.QuizAccess.AccessCode = request.QuizAccess!.AccessCode;
        }
    }

    private static void SetPublicQuiz(QuizInformation quizInfo)
    {
        if (quizInfo.QuizAccess is not null)
        {
            quizInfo.QuizAccess.EndDate = DateTime.Now;
        }
    }
}