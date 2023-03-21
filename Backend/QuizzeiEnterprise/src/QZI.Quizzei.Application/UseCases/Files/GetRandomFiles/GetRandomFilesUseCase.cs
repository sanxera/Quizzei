using QZI.Quizzei.Application.UseCases.Files.GetRandomFiles.Interfaces;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.Files.GetRandomFiles.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.GetRandomFiles;

public class GetRandomFilesUseCase : IGetRandomFilesUseCase
{

    private readonly IQuizInfoFileRepository _fileRepository;

    public GetRandomFilesUseCase(IQuizInfoFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<GetRandomFilesResponse> ExecuteAsync()
    {
        var files = await _fileRepository.GetQuizInfoFileInRange(500);

        var response = new GetRandomFilesResponse();
        foreach (var file in files)
        {
            response.FilesResponse.Add(FileResponse.Create(file.QuizInfoFileUuid, file.Name));
        }

        return response;
    }
}