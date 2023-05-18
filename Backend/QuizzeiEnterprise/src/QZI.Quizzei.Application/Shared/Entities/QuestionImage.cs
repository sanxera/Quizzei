namespace QZI.Quizzei.Application.Shared.Entities;

public class QuestionImage : Entity
{
    public Guid QuestionImageUuid { get; set; }
    public string ImageName { get; set; } = null!;
    public Guid QuestionUuid { get; set; }
    public Question Question { get; set; } = null!;

    public static QuestionImage Create(string imageName)
    {
        return new QuestionImage
        {
            ImageName = imageName,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}