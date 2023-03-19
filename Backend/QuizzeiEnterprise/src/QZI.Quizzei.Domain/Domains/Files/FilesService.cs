using System;
using System.IO;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Files.Responses;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Shared.Constants;
using QZI.Quizzei.Domain.Shared.Enums;
using QZI.Quizzei.Domain.Shared.Interfaces;

namespace QZI.Quizzei.Domain.Domains.Files;

public class FilesService : IFilesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly IQuizInfoFileRepository _fileRepository;
    private readonly IAmazonService _amazonService;

    public FilesService(IQuizInfoFileRepository fileRepository, IUnitOfWork unitOfWork, IQuizInfoRepository quizInfoRepository, IAmazonService amazonService)
    {
        _fileRepository = fileRepository;
        _unitOfWork = unitOfWork;
        _quizInfoRepository = quizInfoRepository;
        _amazonService = amazonService;
    }

    public async Task<UploadFileResponse>  UploadFileToBucket(Guid quizInfoUuid, string fileName, Stream fileStream)
    {
        var file = new QuizInformationFile(fileName, quizInfoUuid);

        await _amazonService.UploadObjectAsync(fileName, FileType.Document, fileStream, ContentType.Pdf);

        await _fileRepository.AddAsync(file);
        await _unitOfWork.SaveChangesAsync();

        return new UploadFileResponse(file.QuizInfoFileUuid, fileName);
    }

    public async Task<GetRandomFilesResponse> GetRandomFiles()
    {
        var files = await _fileRepository.GetQuizInfoFileInRange(500);

        var response = new GetRandomFilesResponse();
        foreach (var file in files)
        {
            response.FilesResponse.Add(new FileResponse(file.QuizInfoFileUuid, file.Name));
        }

        return response;
    }

    public async Task<GetFilesFromQuizInfoResponse> GetFilesFromQuizInfo(Guid quizInfoUuid)
    {
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizInfoUuid);

        var response = new GetFilesFromQuizInfoResponse();
        foreach (var file in quizInfo.Files)
        {
            response.FilesResponse.Add(new FileResponse(file.QuizInfoFileUuid, file.Name));
        }

        return response;
    }

    public async Task<DownloadFileResponse> DownloadFileFromS3(Guid fileUuid)
    {
        var file = await _fileRepository.GetQuizInfoFileById(fileUuid);

        var response = await _amazonService.GetObjectAsync(file.Name, FileType.Document);

        return new DownloadFileResponse(response, file.Name);
    }
}