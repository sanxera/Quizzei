using QZI.Quizzei.Application.Shared.Enums;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Request;

public class CreateQuizInfoRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
    public string ImageName { get; set; } = null!;
    public PermissionType PermissionType { get; set; }
    public CreateQuizAccessRequest QuizAccess { get; set; } = null!;
}