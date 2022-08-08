using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories.Base;

namespace QZI.Quizzei.Domain.Domains.Quiz.Repositories
{
    public interface IQuizInfoRepository : IRepository<QuizInfo>
    {
        Task<QuizInfo> GetQuizInfoById(Guid id);
        Task<IEnumerable<QuizInfo>> GetQuizInfoByUserUuid(Guid userUuid);
        Task<IEnumerable<QuizInfo>> GetQuizInfoByDifferentUsers(Guid userUuid);
    }
}
