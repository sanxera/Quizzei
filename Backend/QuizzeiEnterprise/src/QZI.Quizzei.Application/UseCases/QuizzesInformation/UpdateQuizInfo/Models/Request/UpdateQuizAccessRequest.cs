namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Models.Request;

public class UpdateQuizAccessRequest
{
    public DateTime? InitialDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? AccessCode { get; set; }
}