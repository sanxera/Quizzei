namespace QZI.Quizzei.Application.Shared.Entities;

public class QuestionCategory : Entity
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public bool Active { get; set; }

    public static QuestionCategory CreateQuestionCategory(string name)
    {
        return new QuestionCategory
        {
            Description = name,
            Active = true,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}