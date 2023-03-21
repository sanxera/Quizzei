namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Models.Request;

public class GetQuizzesInfoByUserRequest
{
    public Guid? UserUuid { get; set; }
    public string? Email { get; set; }
}