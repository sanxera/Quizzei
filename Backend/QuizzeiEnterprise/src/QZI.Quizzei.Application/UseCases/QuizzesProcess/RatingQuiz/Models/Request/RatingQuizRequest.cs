namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Models.Request;

public class RatingQuizRequest
{
    public Guid QuizInformationUuid { get; set; }
    public int RatePoints { get; set; }
}