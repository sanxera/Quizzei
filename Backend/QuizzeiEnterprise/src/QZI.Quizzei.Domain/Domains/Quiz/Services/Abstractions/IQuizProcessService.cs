using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Process;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions
{
    public interface IQuizProcessService
    {
        Task<StartQuizProcessResponse> StartQuizProcess(string emailOwner, Guid quizInfoUuid);
    }
}
