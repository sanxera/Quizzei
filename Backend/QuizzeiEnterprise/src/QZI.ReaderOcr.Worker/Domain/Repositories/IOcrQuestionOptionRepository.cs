using QZI.ReaderOcr.Worker.Domain.Abstractions.Repositories;
using QZI.ReaderOcr.Worker.Domain.Entities;

namespace QZI.ReaderOcr.Worker.Domain.Repositories;

public interface IOcrQuestionOptionRepository : IRepository<OcrQuestionOption>
{
    Task<OcrQuestionOption> GetQuestionOptionById(Guid id);
}