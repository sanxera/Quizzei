namespace QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Models.Response;

public class StartQuizProcessResponse
{
    public Guid QuizProcessCreatedUuid { get; set; }

    public static StartQuizProcessResponse Create(Guid quizProcessCreatedUuid) =>
        new()
        {
            QuizProcessCreatedUuid = quizProcessCreatedUuid
        };
}
