using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Question.Domain.Questions.Repositories;
using QZI.Question.Infra.Data.Repository.Base;

namespace QZI.Question.Infra.Data.Repository
{
    public class QuestionRepository : RepositoryBase<Domain.Questions.Entities.Question>, IQuestionRepository
    {
        public QuestionRepository(QuestionContext context) : base(context) { }

        public async Task<Domain.Questions.Entities.Question> GetQuestionById(Guid id)
        {
            return await Context.Questions
                .Include(x => x.Options)
                .FirstOrDefaultAsync(x => x.QuestionUuid == id);
        }
    }
}
