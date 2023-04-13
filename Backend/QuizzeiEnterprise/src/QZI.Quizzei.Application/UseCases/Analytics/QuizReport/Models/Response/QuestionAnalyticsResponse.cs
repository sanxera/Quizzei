namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Response;

public class QuestionAnalyticsResponse
{
    private QuestionAnalyticsResponse(Guid questionUuid, string description, List<OptionAnalyticsResponse> options)
    {
        Description = description;
        Options = options;
        QuestionUuid = questionUuid;
    }

    public Guid QuestionUuid { get; set; }
    public string Description { get; set; } = null!;
    public int TotalAnswers => Options.Select(x => x.TotalOptionAnswers).Sum();
    public int TotalHitPercentage => (Options.Select(x => x.HitQuantity).Sum() * 100) / TotalAnswers;
    public List<OptionAnalyticsResponse> Options { get; set; }

    public static QuestionAnalyticsResponse Create(Guid questionUuid, string description, List<OptionAnalyticsResponse> options) =>
        new(questionUuid, description, options);
}