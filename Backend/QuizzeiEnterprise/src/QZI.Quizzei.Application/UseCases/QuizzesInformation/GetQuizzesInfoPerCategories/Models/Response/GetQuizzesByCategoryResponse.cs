namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Models.Response;

public class GetQuizzesByCategoryResponse
{
    public IList<QuizzesByCategory> QuizzesByCategories { get; set; } = new List<QuizzesByCategory>();
}

public class QuizzesByCategory
{
    public string CategoryName { get; set; } = null!;
    public IList<QuizInfoResponse> QuizzesInfoResponses { get; set; } = new List<QuizInfoResponse>();
}

public class QuizInfoResponse
{
    public Guid QuizInfoUuid { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CategoryDescription { get; set; } = null!;
    public int NumberOfQuestions { get; set; }
    public string OwnerNickName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}