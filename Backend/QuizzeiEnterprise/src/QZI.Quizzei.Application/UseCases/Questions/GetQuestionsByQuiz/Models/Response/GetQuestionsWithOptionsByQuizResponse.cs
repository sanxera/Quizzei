namespace QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Response;

public class GetQuestionsWithOptionsByQuizResponse
{
    public IList<QuestionResponse> Questions { get; set; } = new List<QuestionResponse>();
}

public class QuestionResponse
{
    public Guid QuestionUuid { get; set; }
    public string QuestionDescription { get; set; } = null!;
    public IList<QuestionOptionResponse> Options { get; set; } = new List<QuestionOptionResponse>();

    public static QuestionResponse Create(Guid questionUuid, string questionDescription, IList<QuestionOptionResponse> options) =>
        new()
        {
            Options = options,
            QuestionDescription = questionDescription,
            QuestionUuid = questionUuid
        };
}

public class QuestionOptionResponse
{
    public Guid OptionUuid { get; set; }
    public string OptionDescription { get; set; } = null!;
    public bool IsCorrect { get; set; }

    public static QuestionOptionResponse Create(Guid optionUuid, string optionDescription, bool isCorrect) =>
        new()
        {
            OptionDescription = optionDescription,
            IsCorrect = isCorrect,
            OptionUuid = optionUuid
        };
}