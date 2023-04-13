namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Response;

public class QuizReportResponse
{
    private QuizReportResponse(Guid quizUuid, string quizDescription, int totalCompletedQuiz, int totalNotCompletedQuiz, int totalQuestions, List<QuestionAnalyticsResponse> questions)
    {
        QuizUuid = quizUuid;
        QuizDescription = quizDescription;
        TotalCompletedQuiz = totalCompletedQuiz;
        TotalNotCompletedQuiz = totalNotCompletedQuiz;
        TotalQuestions = totalQuestions;
        Questions = questions;
    }

    public Guid QuizUuid { get; set; }
    public string QuizDescription { get; set; }
    public int TotalCompletedQuiz { get; set; }
    public int TotalNotCompletedQuiz { get; set; }
    public int TotalQuestions { get; set; }
    public List<QuestionAnalyticsResponse> Questions { get; set; }

    public static QuizReportResponse Create(Guid quizUuid, string quizDescription, int totalCompletedQuiz, int totalNotCompletedQuiz, int totalQuestions, List<QuestionAnalyticsResponse> questions)
        => new(quizUuid, quizDescription, totalCompletedQuiz, totalNotCompletedQuiz, totalQuestions, questions);
}