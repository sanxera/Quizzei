namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Responses;

public class QuestionAnalyticsResponse
{
    private QuestionAnalyticsResponse(Guid questionUuid, string description, bool userAnswerIsCorrect, int timer, List<OptionAnalyticsResponse> options)
    {
        QuestionUuid = questionUuid;
        Description = description;
        UserAnswerIsCorrect = userAnswerIsCorrect;
        Options = options;
        Timer = timer;
    }

    public Guid QuestionUuid { get; set; }
    public string Description { get; set; }
    public bool UserAnswerIsCorrect { get; set; }
    public int Timer { get; set; }
    public List<OptionAnalyticsResponse> Options { get; set; }

    public static QuestionAnalyticsResponse Create(Guid questionUuid, string description, bool userAnswerIsCorrect, int timer,
        List<OptionAnalyticsResponse> options) => new(questionUuid, description, userAnswerIsCorrect, timer, options);
}