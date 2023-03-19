using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories.Base;

namespace QZI.Quizzei.Domain.Domains.Quiz.Repositories;

public interface IQuizRateRepository : IRepository<QuizRate>
{
    Task<IList<QuizRate>> GetRatesFromQuizInformation(Guid quizInformationUuid);
    Task<int> GetRateFromQuizProcess(Guid quizProcessUuid);
}