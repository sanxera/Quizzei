namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Responses;

public class QuizReportPerProcessResponse
{
    public QuizReportPerProcessResponse(Guid quizUuid, string quizDescription, int totalQuestions, List<QuestionAnalyticsResponse> questions)
    {
        QuizUuid = quizUuid;
        QuizDescription = quizDescription;
        TotalQuestions = totalQuestions;
        Questions = questions;
    }

    public Guid QuizUuid { get; set; }
    public string QuizDescription { get; set; }
    public int TotalQuestions { get; set; }
    public List<QuestionAnalyticsResponse> Questions { get; set; }

    public static QuizReportPerProcessResponse Create(Guid quizUuid, string quizDescription, int totalQuestions,
        List<QuestionAnalyticsResponse> questions) => new(quizUuid, quizDescription, totalQuestions, questions);
}