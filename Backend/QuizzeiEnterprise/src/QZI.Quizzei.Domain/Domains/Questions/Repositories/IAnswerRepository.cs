using System;
using QZI.Quizzei.Domain.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Entities;

namespace QZI.Quizzei.Domain.Domains.Questions.Repositories;

public interface IAnswerRepository : IRepository<Answer>
{
    int GetCorrectAnswersCountByQuizProcess(Guid processUuid);
}