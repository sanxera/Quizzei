using System.ComponentModel.DataAnnotations.Schema;
using QZI.Quizzei.Application.Shared.Enums;

namespace QZI.Quizzei.Application.Shared.Entities;

public class QuizProcess : Entity
{
    public Guid QuizProcessUuid { get; set; }
    public Guid QuizInfoUuid { get; set; }
    public Guid UserUuid { get; set; }
    public QuizProcessStatus Status { get; set; }
    [NotMapped] public QuizInformation QuizInformation { get; set; } = null!;

    public static QuizProcess Create(Guid quizUuid, Guid userUuid)
    {
        return new QuizProcess
        {
            QuizInfoUuid = quizUuid,
            UserUuid = userUuid,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin",
            Status = QuizProcessStatus.Started
        };
    }
}