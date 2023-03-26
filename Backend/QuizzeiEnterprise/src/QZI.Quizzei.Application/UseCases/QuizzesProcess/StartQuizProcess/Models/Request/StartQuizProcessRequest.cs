namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Request;

public class StartQuizProcessRequest
{
    public Guid QuizUuid { get; set; }
    public string EmailOwner { get; set; } = null!;
    public AccessInformationRequest? AccessInformation { get; set; }
}