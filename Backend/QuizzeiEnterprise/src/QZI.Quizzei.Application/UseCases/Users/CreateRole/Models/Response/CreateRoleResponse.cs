namespace QZI.Quizzei.Application.UseCases.Users.CreateRole.Models.Response;

public class CreateRoleResponse
{
    public Guid CreatedRoleUuid { get; set; }

    public static CreateRoleResponse Create(Guid createdRoleUuid) =>
        new()
        {
            CreatedRoleUuid = createdRoleUuid
        };
}