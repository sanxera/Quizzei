namespace QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Models.Request;

public class UpdateQuestionsRequest
{
    public Guid? QuizInfoUuid { get; set; }
    public IList<UpdateQuestions> Questions { get; set; } = new List<UpdateQuestions>();
}

public class UpdateQuestions
{
    public Guid QuestionUuid { get; set; }
    public string Description { get; set; } = string.Empty;
    public ActionEnum Action { get; set; }
    public IList<UpdateImages> Images { get; set; } = new List<UpdateImages>();
    public IList<UpdateOptions> Options { get; set; } = new List<UpdateOptions>();
}

public class UpdateOptions
{
    public Guid OptionUuid { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public ActionEnum Action { get; set; }
}

public class UpdateImages
{
    public Guid QuestionImageUuid { get; set; }
    public string ImageName { get; set; } = string.Empty;
}

public enum ActionEnum
{
    Create = 0,
    Update = 1,
    Delete = 2,
    NonAction = 3
}