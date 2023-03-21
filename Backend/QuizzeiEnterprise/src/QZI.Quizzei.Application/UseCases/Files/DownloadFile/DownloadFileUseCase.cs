using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Interfaces;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.DownloadFile;

public class DownloadFileUseCase : IDownloadFileUseCase
{
    private readonly IQuizInfoFileRepository _fileRepository;
    private readonly IAmazonService _amazonService;

    public DownloadFileUseCase(IQuizInfoFileRepository fileRepository, IAmazonService amazonService)
    {
        _fileRepository = fileRepository;
        _amazonService = amazonService;
    }

    public async Task<DownloadFileResponse> ExecuteAsync(DownloadFileRequest request)
    {
        var file = await _fileRepository.GetQuizInfoFileById(request.FileUuid);

        var response = await _amazonService.GetObjectAsync(file.Name, FileType.Document);

        return DownloadFileResponse.Create(response, file.Name);
    }
}