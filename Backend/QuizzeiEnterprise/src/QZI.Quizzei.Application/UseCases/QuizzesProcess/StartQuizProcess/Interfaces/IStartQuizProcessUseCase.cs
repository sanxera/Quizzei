using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Interfaces;

public interface IStartQuizProcessUseCase
{
    Task<StartQuizProcessResponse> ExecuteAsync(StartQuizProcessRequest request);
}