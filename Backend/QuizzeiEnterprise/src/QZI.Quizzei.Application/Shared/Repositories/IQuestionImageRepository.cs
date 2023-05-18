using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Application.Shared.Repositories;

public interface IQuestionImageRepository : IRepository<QuestionImage>
{
    Task<QuestionImage?> GetQuestionImageById(Guid questionImageUuid);
    Task SetQuestionUuid(Guid questionImageUuid, Guid questionUuid);
    void Delete(QuestionImage image);
    void DeleteById(Guid questionImageUuid);
}