namespace QZI.Quizzei.Application.UseCases.Files.ReadPdf.Models.Response;

public class GetOcrQuestionsWithOptionsByQuizResponse
{
    public IList<OcrQuestionResponse> Questions { get; set; } = new List<OcrQuestionResponse>();
}

public class OcrQuestionResponse
{
    public string QuestionDescription { get; set; } = null!;
    public IList<OcrQuestionOptionResponse> Options { get; set; } = new List<OcrQuestionOptionResponse>();

    public static OcrQuestionResponse Create(string questionDescription) 
        => new()
        {
            QuestionDescription = questionDescription
        };
}

public class OcrQuestionOptionResponse
{
    public string OptionDescription { get; set; } = null!;

    public static OcrQuestionOptionResponse Create(string optionDescription) 
        =>
        new()
        {
            OptionDescription = optionDescription
        };
}