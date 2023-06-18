namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Models.Response;

public class QuizReportPerCategoryResponse
{
    public QuizReportPerCategoryResponse(Guid quizUuid, int totalCompletedQuiz, int totalNotCompletedQuiz, int totalQuestions, List<QuestionCategoryAnalyticsResponse> questionsCategories, string quizDescription)
    {
        QuizUuid = quizUuid;
        TotalCompletedQuiz = totalCompletedQuiz;
        TotalNotCompletedQuiz = totalNotCompletedQuiz;
        TotalQuestions = totalQuestions;
        QuestionsCategories = questionsCategories;
        QuizDescription = quizDescription;
    }

    public Guid QuizUuid { get; set; }
    public string QuizDescription { get; set; }
    public int TotalCompletedQuiz { get; set; }
    public int TotalNotCompletedQuiz { get; set; }
    public int TotalQuestions { get; set; }
    public List<QuestionCategoryAnalyticsResponse> QuestionsCategories { get; set; }

    public static QuizReportPerCategoryResponse Create(Guid quizUuid, int totalCompletedQuiz, int totalNotCompletedQuiz,
        int totalQuestions, List<QuestionCategoryAnalyticsResponse> questionsCategories, string quizDescription)
        => new(quizUuid, totalCompletedQuiz, totalNotCompletedQuiz, totalQuestions, questionsCategories, quizDescription);
}

public class QuestionCategoryAnalyticsResponse
{
    public QuestionCategoryAnalyticsResponse(int questionCategoryId, int totalQuestions, int totalHitPercentage, string questionCategoryDescription, List<QuestionAnalyticsResponse> questions)
    {
        QuestionCategoryId = questionCategoryId;
        TotalQuestions = totalQuestions;
        TotalHitPercentage = totalHitPercentage;
        QuestionCategoryDescription = questionCategoryDescription;
        Questions = questions;
    }

    public int QuestionCategoryId { get; set; }
    public string QuestionCategoryDescription { get; set; }
    public int TotalQuestions { get; set; }
    public int TotalHitPercentage { get; set; }
    public List<QuestionAnalyticsResponse> Questions { get; set; }

    public static QuestionCategoryAnalyticsResponse Create(int questionCategoryId, int totalQuestions, int totalHitPercentage, string questionCategoryDescription, List<QuestionAnalyticsResponse> questions)
        => new(questionCategoryId, totalQuestions, totalHitPercentage, questionCategoryDescription, questions);
}

public class QuestionAnalyticsResponse
{
    public QuestionAnalyticsResponse(Guid questionUuid, string description, int totalAnswers, int totalHitPercentage, List<OptionAnalyticsResponse> options)
    {
        QuestionUuid = questionUuid;
        Description = description;
        TotalAnswers = totalAnswers;
        TotalHitPercentage = totalHitPercentage;
        Options = options;
    }

    public Guid QuestionUuid { get; set; }
    public string Description { get; set; }
    public int TotalAnswers { get; set; }
    public int TotalHitPercentage { get; set; }
    public List<OptionAnalyticsResponse> Options { get; set; }

    public static QuestionAnalyticsResponse Create(Guid questionUuid, string description, int totalAnswers, int totalHitPercentage, List<OptionAnalyticsResponse> options)
        => new(questionUuid, description, totalAnswers, totalHitPercentage, options);
}

public class OptionAnalyticsResponse
{
    public OptionAnalyticsResponse(Guid optionUuid, string description, bool isCorrect, int totalOptionAnswers, int hitQuantity, int hitPercentage)
    {
        OptionUuid = optionUuid;
        Description = description;
        IsCorrect = isCorrect;
        TotalOptionAnswers = totalOptionAnswers;
        HitQuantity = hitQuantity;
        HitPercentage = hitPercentage;
    }

    public Guid OptionUuid { get; set; }
    public string Description { get; set; }
    public bool IsCorrect { get; set; }
    public int TotalOptionAnswers { get; set; }
    public int TotalOptionAnswersPercentage { get; set; }
    public int HitQuantity { get; set; }
    public int HitPercentage { get; set; }

    public static OptionAnalyticsResponse Create(Guid optionUuid, string description, bool isCorrect, int totalOptionAnswers, int hitQuantity, int hitPercentage)
        => new(optionUuid, description, isCorrect, totalOptionAnswers, hitQuantity, hitPercentage);
}