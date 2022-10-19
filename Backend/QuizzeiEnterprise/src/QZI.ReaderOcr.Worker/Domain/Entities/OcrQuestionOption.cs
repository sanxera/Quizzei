using QZI.ReaderOcr.Worker.Domain.Abstractions.Entities;

namespace QZI.ReaderOcr.Worker.Domain.Entities
{
    public class OcrQuestionOption : OcrEntity
    {
        public Guid QuestionOptionUuid { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionUuid { get; set; }
        public OcrQuestion? Question { get; set; }

        public OcrQuestionOption(string description, bool isCorrect)
        {
            Description = description;
            IsCorrect = isCorrect;
            CreatedBy = "admin";
            CreatedAt = DateTime.Now;
        }
    }
}
