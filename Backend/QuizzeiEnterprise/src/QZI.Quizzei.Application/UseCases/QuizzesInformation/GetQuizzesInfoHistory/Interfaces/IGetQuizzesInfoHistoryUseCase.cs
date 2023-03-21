using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Interfaces;

public interface IGetQuizzesInfoHistoryUseCase
{
    Task<GetQuizzesInfoHistoryResponse> ExecuteAsync(GetQuizzesInfoHistoryRequest request);
}