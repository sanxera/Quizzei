namespace QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Models.Request;

public class UpdateQuestionsRequest
{
    public Guid? QuizInfoUuid { get; set; }
    public IList<UpdateQuestions> Questions { get; set; } = new List<UpdateQuestions>();
}

public class UpdateQuestions
{
    public Guid QuestionUuid { get; set; }
    public string Description { get; set; }
    public ActionEnum Action { get; set; }
    public IList<UpdateOptions> Options { get; set; } = new List<UpdateOptions>();
}

public class UpdateOptions
{
    public Guid OptionUuid { get; set; }
    public string Description { get; set; }
    public bool IsCorrect { get; set; }
    public ActionEnum Action { get; set; }
}

public enum ActionEnum
{
    Create = 0,
    Update = 1,
    Delete = 2
}