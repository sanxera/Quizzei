using Microsoft.EntityFrameworkCore;
using QZI.ReaderOcr.Worker.Data.Repositories.Base;
using QZI.ReaderOcr.Worker.Domain.Entities;
using QZI.ReaderOcr.Worker.Domain.Repositories;

namespace QZI.ReaderOcr.Worker.Data.Repositories
{
    public class OcrQuestionOptionRepository : RepositoryBase<OcrQuestionOption>, IOcrQuestionOptionRepository
    {
        public OcrQuestionOptionRepository(QuizzeiOcrContext context) : base(context) { }

        public async Task<OcrQuestionOption> GetQuestionOptionById(Guid id)
        {
            return await Context.Options!.FirstOrDefaultAsync(x => x.QuestionOptionUuid == id);
        }
    }
}
