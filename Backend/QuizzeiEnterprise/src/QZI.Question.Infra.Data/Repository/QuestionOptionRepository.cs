using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Question.Domain.Questions.Entities;
using QZI.Question.Domain.Questions.Repositories;
using QZI.Question.Infra.Data.Repository.Base;

namespace QZI.Question.Infra.Data.Repository
{
    public class QuestionOptionRepository : RepositoryBase<QuestionOption>, IQuestionOptionRepository
    {
        public QuestionOptionRepository(QuestionContext context) : base(context) { }

        public async Task<QuestionOption> GetQuestionOptionById(Guid id)
        {
            return await Context.QuestionOptions.FirstOrDefaultAsync(x => x.QuestionOptionUuid == id);
        }
    }
}
