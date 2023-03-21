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

        _quizInfoRepository.Update(quizInfo);
        await _unitOfWork.SaveChangesAsync();
    }
}