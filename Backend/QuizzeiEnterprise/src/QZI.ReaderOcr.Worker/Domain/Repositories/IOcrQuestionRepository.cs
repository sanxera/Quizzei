using QZI.ReaderOcr.Worker.Domain.Abstractions.Repositories;
using QZI.ReaderOcr.Worker.Domain.Entities;

namespace QZI.ReaderOcr.Worker.Domain.Repositories;

public interface IOcrQuestionRepository : IRepository<OcrQuestion>
{
    Task<OcrQuestion> GetQuestionById(Guid id);
}