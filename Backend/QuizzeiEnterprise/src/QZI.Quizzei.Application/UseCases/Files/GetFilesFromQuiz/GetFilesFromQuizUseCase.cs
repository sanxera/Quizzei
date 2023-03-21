using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Interfaces;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz;

//TODO: REVISAR DE FAZ SENTIDO ESSE METODO ESTAR AQUI
public class GetFilesFromQuizUseCase : IGetFilesFromQuizUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;

    public GetFilesFromQuizUseCase(IQuizInfoRepository quizInfoRepository)
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