using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Questions.Services.Requests;
using QZI.Quizzei.Domain.Domains.Questions.Services.Responses;

namespace QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;

public interface IAnswerService
{
    Task<AnswerQuestionResponse> AnswerQuestion(string emailOwner, Guid quizProcessUuid, AnswerQuestionRequest request);
}