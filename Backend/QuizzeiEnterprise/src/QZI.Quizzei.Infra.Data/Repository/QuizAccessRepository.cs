using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuizAccessRepository : RepositoryBase<QuizAccess>, IQuizAccessRepository
{
    public QuizAccessRepository(QuizzeiContext context) : base(context) { }
}