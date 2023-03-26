namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Request;

public class CreateQuizAccessRequest
{
    public DateTime? InitialDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? AccessCode { get; set; }
}