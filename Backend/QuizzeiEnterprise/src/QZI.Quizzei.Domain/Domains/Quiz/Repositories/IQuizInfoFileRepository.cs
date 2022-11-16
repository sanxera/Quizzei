using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories.Base;

namespace QZI.Quizzei.Domain.Domains.Quiz.Repositories
{
    public interface IQuizInfoFileRepository : IRepository<QuizInformationFile>
    {
        Task<QuizInformationFile> GetQuizInfoFileById(Guid id);
        Task<IList<QuizInformationFile>> GetQuizInfoFileInRange(int range);

    }
}
