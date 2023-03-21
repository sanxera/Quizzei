namespace QZI.Quizzei.Application.Shared.Entities;

public class QuestionOption : Entity
{
    public Guid QuestionOptionUuid { get; set; }
    public string Description { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public Guid QuestionUuid { get; set; }
    public Question Question { get; set; } = null!;

    public static QuestionOption CreateAnyOptions(string description, bool isCorrect)
    {
        return new QuestionOption
        {
            Description = description,
            IsCorrect = isCorrect,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}