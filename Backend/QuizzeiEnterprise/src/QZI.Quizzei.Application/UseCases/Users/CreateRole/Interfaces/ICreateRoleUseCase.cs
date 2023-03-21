using QZI.Quizzei.Application.UseCases.Users.CreateRole.Models.Response;
using QZI.Quizzei.Application.UseCases.Users.CreateRole.Models.Request;

namespace QZI.Quizzei.Application.UseCases.Users.CreateRole.Interfaces;

public interface ICreateRoleUseCase
{
    Task<CreateRoleResponse> ExecuteAsync(CreateRoleRequest request);
}