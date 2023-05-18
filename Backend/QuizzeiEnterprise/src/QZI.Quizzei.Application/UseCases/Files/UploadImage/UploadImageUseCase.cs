using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.Files.UploadImage.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.UploadImage.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.UploadImage.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.UploadImage;

public class UploadImageUseCase : IUploadImageUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionImageRepository _questionImageRepository;
    private readonly IAmazonService _amazonService;

    public UploadImageUseCase(IUnitOfWork unitOfWork, IAmazonService amazonService, IQuestionImageRepository questionImageRepository)
    {
        _unitOfWork = unitOfWork;
        _amazonService = amazonService;
        _questionImageRepository = questionImageRepository;
    }

    public async Task<UploadImageResponse> ExecuteAsync(UploadImageRequest request)
    {
        var questionImage = QuestionImage.Create($"{Guid.NewGuid()}-{request.FileName}");
        await _amazonService.UploadObjectAsync(request.FileName, FileType.Image, request.FileStream, request.ContentType);

        await _questionImageRepository.AddAsync(questionImage);
        await _unitOfWork.SaveChangesAsync();

        var imageUrl = await _amazonService.GetObjectUrl(questionImage.ImageName, FileType.Image);

        return UploadImageResponse.Create(questionImage.QuestionImageUuid, questionImage.ImageName, imageUrl);
    }
}