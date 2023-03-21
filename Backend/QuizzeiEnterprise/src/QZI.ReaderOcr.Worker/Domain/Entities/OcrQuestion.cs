using QZI.ReaderOcr.Worker.Domain.Abstractions.Entities;

namespace QZI.ReaderOcr.Worker.Domain.Entities;

public class OcrQuestion : OcrEntity
{
    public Guid QuestionUuid { get; set; }
    public string? Description { get; set; }
    public ICollection<OcrQuestionOption> Options { get; set; } = new List<OcrQuestionOption>();

    public OcrQuestion(string? description)
    {
        Description = description;
        CreatedBy = "Admin";
        CreatedAt = DateTime.Now;
    }
}