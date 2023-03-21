namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Models.Response;

public class GetQuizzesInfoHistoryResponse
{
    public Guid UserUuid { get; set; }
    public IList<QuizHistoryInformation> QuizzesHistoryInformation { get; set; } = new List<QuizHistoryInformation>();
}

public class QuizHistoryInformation
{
    public Guid QuizInfoUuid { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CategoryDescription { get; set; } = null!;
    public int NumberOfQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int Rate { get; set; }
    public string OwnerNickName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}