using Microsoft.EntityFrameworkCore;
using QZI.ReaderOcr.Worker.Data.Repositories.Base;
using QZI.ReaderOcr.Worker.Domain.Entities;
using QZI.ReaderOcr.Worker.Domain.Repositories;

namespace QZI.ReaderOcr.Worker.Data.Repositories
{
    public class OcrQuestionRepository : RepositoryBase<OcrQuestion>, IOcrQuestionRepository
    {
        public OcrQuestionRepository(QuizzeiOcrContext context) : base(context) { }

        public async Task<OcrQuestion> GetQuestionById(Guid id)
        {
            return await Context.Questions!
                .Include(x => x.Options)
                .FirstOrDefaultAsync(x => x.QuestionUuid == id);
        }
    }
}
