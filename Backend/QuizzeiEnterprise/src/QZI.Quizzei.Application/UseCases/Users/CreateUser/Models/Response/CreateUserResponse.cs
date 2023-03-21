namespace QZI.Quizzei.Application.UseCases.Users.CreateUser.Models.Response;

public class CreateUserResponse
{
    public Guid CreatedUserUuid { get; set; }

    public static CreateUserResponse Create(Guid createdUserUuid) =>
        new()
        {
            CreatedUserUuid = createdUserUuid
        };
}