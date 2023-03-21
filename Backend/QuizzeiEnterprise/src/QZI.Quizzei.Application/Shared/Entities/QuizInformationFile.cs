namespace QZI.Quizzei.Application.Shared.Entities;

public class QuizInformationFile : Entity
{
    public Guid QuizInfoFileUuid { get; set; }
    public string Name { get; set; } = null!;
    public Guid QuizInfoUuid { get; set; }
    public QuizInformation QuizInformation { get; set; } = null!;

    public QuizInformationFile(string name, Guid quizInfoUuid)
    {
        Name = name;
        QuizInfoUuid = quizInfoUuid;
        CreatedAt = DateTime.Now;
        CreatedBy = "Admin";
    }
}