namespace QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Response;

public class GetQuestionsWithOptionsByQuizResponse
{
    public IList<QuestionResponse> Questions { get; set; } = new List<QuestionResponse>();
}

public class QuestionResponse
{
    public Guid QuestionUuid { get; set; }
    public string QuestionDescription { get; set; } = null!;
    public IList<QuestionImageResponse> ImagesUrl { get; set; } = new List<QuestionImageResponse>();
    public IList<QuestionOptionResponse> Options { get; set; } = new List<QuestionOptionResponse>();

    public static QuestionResponse Create(Guid questionUuid, string questionDescription, List<QuestionImageResponse> imagesUrl, IList<QuestionOptionResponse> options) =>
        new()
        {
            Options = options,
            QuestionDescription = questionDescription,
            QuestionUuid = questionUuid,
            ImagesUrl = imagesUrl
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

public class QuestionImageResponse
{
    public Guid QuestionImageUuid { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public static QuestionImageResponse Create(Guid imageUuid, string imageName, string imageUrl) => new()
    {
        QuestionImageUuid = imageUuid,
        ImageName = imageName,
        ImageUrl = imageUrl
    };
}