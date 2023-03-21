namespace QZI.Quizzei.Application.Shared.Entities;

public class Answer : Entity
{
    public Guid AnswerUuid { get; set; }
    public Guid QuizProcessUuid { get; set; }
    public Guid QuestionUuid { get; set; }
    public Guid QuestionOptionUuid { get; set; }
    public Guid UserUuid { get; set; }
    public bool CorrectAnswer{ get; set; }

    public static Answer CreateAnswer(Guid option, Guid question, Guid quizProcess, Guid userUuid, bool correctAnswer)
    {
        return new Answer
        {
            QuizProcessUuid = quizProcess,
            QuestionOptionUuid = option,
            QuestionUuid = question,
            UserUuid = userUuid,
            CorrectAnswer = correctAnswer,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}