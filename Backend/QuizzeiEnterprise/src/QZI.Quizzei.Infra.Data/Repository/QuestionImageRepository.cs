using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Infra.Data.Repository.Base;

namespace QZI.Quizzei.Infra.Data.Repository;

public class QuestionImageRepository : RepositoryBase<QuestionImage>, IQuestionImageRepository
{
    public QuestionImageRepository(QuizzeiContext context) : base(context) { }

    public async Task<QuestionImage?> GetQuestionImageById(Guid questionImageUuid)
    {
        return await Context.QuestionImages.FirstOrDefaultAsync(x => x.QuestionImageUuid == questionImageUuid);
    }

    public async Task SetQuestionUuid(Guid questionImageUuid, Guid questionUuid)
    {
        var questionImage = await Context.QuestionImages.FirstOrDefaultAsync(x => x.QuestionImageUuid == questionImageUuid);

        if (questionImage == null)
            return;

        questionImage.QuestionUuid = questionUuid;
    }

    public void Delete(QuestionImage image)
    {
        Context.QuestionImages.Remove(image);
    }

    public void DeleteById(Guid questionImageUuid)
    {
        Context.QuestionImages
            .Where(x => x.QuestionImageUuid == questionImageUuid)
            .ExecuteDelete();
    }
}