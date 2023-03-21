using QZI.Quizzei.Application.UseCases.Users.CreateUser.Models.Request;
using QZI.Quizzei.Application.UseCases.Users.CreateUser.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Users.CreateUser.Interfaces;

public interface ICreateUserUseCase
{
    Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request);
}