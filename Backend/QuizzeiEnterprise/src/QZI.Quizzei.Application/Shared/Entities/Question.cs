namespace QZI.Quizzei.Application.Shared.Entities;

public class Question : Entity
{
    public Guid QuestionUuid { get; set; }
    public string Description { get; set; } = null!;
    public Guid? QuizInfoUuid { get; set; }
    public int CategoryId { get; set; }
    public ICollection<QuestionImage> Images { get; set; } = new List<QuestionImage>();
    public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();

    public static Question CreateQuestion(string description, int categoryId, Guid quizInfoUuid)
    {
        return new Question
        {
            Description = description,
            QuizInfoUuid = quizInfoUuid,
            CategoryId = categoryId,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}