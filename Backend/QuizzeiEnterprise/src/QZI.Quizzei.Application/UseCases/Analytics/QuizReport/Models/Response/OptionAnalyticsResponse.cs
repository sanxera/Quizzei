namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Response;

public class OptionAnalyticsResponse
{
    private OptionAnalyticsResponse(Guid optionUuid, string description, int totalAnswers, int hitQuantity, int hitPercentage)
    {
        OptionUuid = optionUuid;
        Description = description;
        TotalAnswers = totalAnswers;
        HitQuantity = hitQuantity;
        HitPercentage = hitPercentage;
    }

    public Guid OptionUuid { get; set; }
    public string Description { get; set; }
    public int TotalAnswers { get; set; }
    public int HitQuantity { get; set; }
    public int HitPercentage { get; set; }

    public static OptionAnalyticsResponse Create(Guid optionUuid, string description, int totalAnswers, int hitQuantity, int hitPercentage) 
        => new(optionUuid, description, totalAnswers, hitQuantity, hitPercentage);
}