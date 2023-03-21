namespace QZI.Quizzei.Application.Shared.Entities;

public class QuizInformation : Entity
{
    public Guid QuizInfoUuid { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Points { get; set; }
    public bool Active { get; set; }
    public int CategoryId { get; set; }
    public string? ImageName { get; set; }
    public Guid UserOwnerId { get; set; }

    public ICollection<QuizInformationFile> Files { get; set; } = new List<QuizInformationFile>();

    public static QuizInformation Create(string title, string description, Guid userOwner, int categoryId, string imageName) =>
        new()
        {
            QuizInfoUuid = Guid.NewGuid(),
            Title = title,
            Description = description,
            Active = true,
            UserOwnerId = userOwner,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin",
            CategoryId = categoryId,
            ImageName = imageName
        };

    public void UpdateQuizRate(int rate) => Points = rate;
}