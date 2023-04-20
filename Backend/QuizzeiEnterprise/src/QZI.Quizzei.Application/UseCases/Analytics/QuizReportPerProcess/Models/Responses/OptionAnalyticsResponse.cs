namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Responses;

public class OptionAnalyticsResponse
{
    private OptionAnalyticsResponse(Guid optionUuid, string description, bool isCorrect, bool userCheck)
    {
        OptionUuid = optionUuid;
        Description = description;
        IsCorrect = isCorrect;
        UserCheck = userCheck;
    }

    public Guid OptionUuid { get; set; }
    public string Description { get; set; }
    public bool IsCorrect { get; set; }
    public bool UserCheck { get; set; }

    public static OptionAnalyticsResponse Create(Guid optionUuid, string description, bool isCorrect, bool userCheck)
        => new(optionUuid, description, isCorrect, userCheck);
}