namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Response;

public class CreateQuizInfoResponse
{
    public Guid CreatedQuizUuid { get; set; }

    public static CreateQuizInfoResponse Create(Guid createdQuizUuid) =>
        new()
        {
            CreatedQuizUuid = createdQuizUuid
        };
}