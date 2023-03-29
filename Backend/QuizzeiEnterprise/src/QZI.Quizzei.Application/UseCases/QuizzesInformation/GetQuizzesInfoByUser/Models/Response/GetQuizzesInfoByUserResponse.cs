using QZI.Quizzei.Application.Shared.Enums;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Models.Response;

public class GetQuizzesInfoByUserResponse
{
    public IList<QuizInfoResponse> QuizzesInfoDto { get; set; } = new List<QuizInfoResponse>();
}

public class QuizInfoResponse
{
    public Guid QuizInfoUuid { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CategoryDescription { get; set; } = null!;
    public int NumberOfQuestions { get; set; }
    public int Rate { get; set; }
    public string OwnerNickName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public PermissionType PermissionType { get; set; }
    public QuizAccessResponse? QuizAccess { get; set; }
}

public class QuizAccessResponse
{
    public DateTime? InitialDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? AccessCode { get; set; }
}