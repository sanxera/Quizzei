namespace QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Models.Requests;

public class AnswerQuizRequest
{
    public IList<AnswersRequest> Answers { get; set; } = new List<AnswersRequest>();
}

public class AnswersRequest
{
    public Guid QuestionUuid { get; set; }
    public Guid OptionUuid { get; set; }
}