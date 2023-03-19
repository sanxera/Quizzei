using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories.Base;

namespace QZI.Quizzei.Domain.Domains.Quiz.Repositories;

public interface IQuizInfoRepository : IRepository<QuizInformation>
{
    Task<QuizInformation> GetQuizInfoById(Guid id);
    Task<IEnumerable<QuizInformation>> GetQuizInfoByUserUuid(Guid userUuid);
    Task<IEnumerable<QuizInformation>> GetQuizInfoByDifferentUsers(Guid userUuid);
    Task<IEnumerable<QuizInformation>> GetQuizzesByTitle(string name);
    Task<IEnumerable<QuizInformation>> GetQuizzesByCategory(int categoryId);
}