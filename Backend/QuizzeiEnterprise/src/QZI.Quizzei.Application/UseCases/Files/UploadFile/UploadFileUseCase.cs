using QZI.Quizzei.Application.Shared.Constants;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.Files.UploadFile.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.UploadFile.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.UploadFile;

public class UploadFileUseCase : IUploadFileUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuizInfoFileRepository _fileRepository;
    private readonly IAmazonService _amazonService;

    public UploadFileUseCase(IUnitOfWork unitOfWork, IQuizInfoFileRepository fileRepository, IAmazonService amazonService)
    {
        _unitOfWork = unitOfWork;
        _fileRepository = fileRepository;
        _amazonService = amazonService;
    }

    public async Task<UploadFileResponse> ExecuteAsync(Guid quizInfoUuid, string fileName, Stream fileStream)
    {
        var file = new QuizInformationFile(fileName, quizInfoUuid);

        await _amazonService.UploadObjectAsync(fileName, FileType.Document, fileStream, ContentType.Pdf);

        await _fileRepository.AddAsync(file);
        await _unitOfWork.SaveChangesAsync();

        return UploadFileResponse.Create(file.QuizInfoFileUuid, fileName);
    }
}