namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerUser.Models.Requests;

public class QuizReportPerUseRequest
{
    public Guid QuizUuid { get; set; }
    public string UserEmail { get; set; } = null!;
}