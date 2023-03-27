using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoFiles;

public class GetQuizzesInfoFilesUseCase : IGetQuizzesInfoFilesUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;

    public GetQuizzesInfoFilesUseCase(IQuizInfoRepository quizInfoRepository)
    {
        _quizInfoRepository = quizInfoRepository;
    }

    public async Task<GetFilesFromQuizInfoResponse> ExecuteAsync(GetFilesFromQuizInfoRequest request)
    {
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(request.QuizInfoUuid);

        var response = new GetFilesFromQuizInfoResponse();
        foreach (var file in quizInfo.Files)
        {
            response.FilesResponse.Add(FileResponse.Create(file.QuizInfoFileUuid, file.Name));
        }

        return response;
    }
}