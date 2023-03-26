namespace QZI.Quizzei.Application.Shared.Entities;

public class QuizAccess : Entity
{
    public Guid QuizAccessUuid { get; set; }
    public Guid QuizInfoUuid { get; set; }
    public DateTime? InitialDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? AccessCode { get; set; }

    public QuizInformation QuizInfo { get; set; } = null!;

    public static QuizAccess Create(Guid quizInfoUuid, DateTime? initialDate, DateTime? endDate, string? accessCode) =>
        new()
        {
            QuizInfoUuid = quizInfoUuid,
            InitialDate = initialDate,
            EndDate = endDate,
            AccessCode = accessCode,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
}