using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuizInfoFileRepository : IRepository<QuizInformationFile>
{
    Task<QuizInformationFile> GetQuizInfoFileById(Guid id);
    Task<IList<QuizInformationFile>> GetQuizInfoFileInRange(int range);

}