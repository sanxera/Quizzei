namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Response;

public class OptionAnalyticsResponse
{
    private OptionAnalyticsResponse(Guid optionUuid, string description, int totalOptionAnswers, int hitQuantity, int hitPercentage, bool isCorrect)
    {
        OptionUuid = optionUuid;
        Description = description;
        TotalOptionAnswers = totalOptionAnswers;
        HitQuantity = hitQuantity;
        HitPercentage = hitPercentage;
        IsCorrect = isCorrect;
    }

    public Guid OptionUuid { get; set; }
    public string Description { get; set; }
    public bool IsCorrect { get; set; }
    public int TotalOptionAnswers { get; set; }
    public int HitQuantity { get; set; }
    public int HitPercentage { get; set; }

    public static OptionAnalyticsResponse Create(Guid optionUuid, string description, int totalAnswers, int hitQuantity, int hitPercentage, bool isCorrect) 
        => new(optionUuid, description, totalAnswers, hitQuantity, hitPercentage, isCorrect);
}