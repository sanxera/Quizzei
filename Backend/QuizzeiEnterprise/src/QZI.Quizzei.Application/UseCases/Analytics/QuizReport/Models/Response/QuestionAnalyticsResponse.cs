namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Response;

public class QuestionAnalyticsResponse
{
    private QuestionAnalyticsResponse(Guid questionUuid, string description, int totalAnswers, int totalHitPercentage, int averageTimer, List<OptionAnalyticsResponse> options)
    {
        Description = description;
        Options = options;
        AverageTimer = averageTimer;
        TotalAnswers = totalAnswers;
        TotalHitPercentage = totalHitPercentage;
        QuestionUuid = questionUuid;
    }

    public Guid QuestionUuid { get; set; }
    public string Description { get; set; } = null!;
    public int TotalAnswers { get; set; }
    public int TotalHitPercentage { get; set; }
    public int AverageTimer { get; set; }
    public List<OptionAnalyticsResponse> Options { get; set; }

    public static QuestionAnalyticsResponse Create(Guid questionUuid, string description, int totalAnswers, int totalHitPercentage, int averageTimer, List<OptionAnalyticsResponse> options) =>
        new(questionUuid, description, totalAnswers, totalHitPercentage, averageTimer, options);
}