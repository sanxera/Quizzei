using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.UseCases.Files.DeleteImage.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.DeleteImage.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.DeleteImage.Models.Response;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.Shared.UnitOfWork;

namespace QZI.Quizzei.Application.UseCases.Files.DeleteImage;

public class DeleteImageUseCase : IDeleteImageUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionImageRepository _questionImageRepository;
    private readonly IAmazonService _amazonService;

    public DeleteImageUseCase(IUnitOfWork unitOfWork, IQuestionImageRepository questionImageRepository, IAmazonService amazonService)
    {
        _unitOfWork = unitOfWork;
        _questionImageRepository = questionImageRepository;
        _amazonService = amazonService;
    }

    public async Task<DeleteImageResponse> ExecuteAsync(DeleteImageRequest request)
    {
        var questionImage = await _questionImageRepository.GetQuestionImageById(request.QuestionImageUuid);

        if (questionImage == null)
            return DeleteImageResponse.Create(false);

        await _amazonService.DeleteObjectAsync(questionImage.ImageName, FileType.Image);

        _questionImageRepository.DeleteById(questionImage.QuestionImageUuid);
        await _unitOfWork.SaveChangesAsync();

        return DeleteImageResponse.Create(true);
    }
}