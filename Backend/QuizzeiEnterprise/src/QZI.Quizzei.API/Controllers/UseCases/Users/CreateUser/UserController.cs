using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QZI.Quizzei.Application.UseCases.Users.CreateUser.Interfaces;
using QZI.Quizzei.Application.UseCases.Users.CreateUser.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Users.CreateUser;

[Route("api/users")]
public class UserController : Controller
{
    private readonly ICreateUserUseCase _useCase;

    public UserController(ICreateUserUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("create-user")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _useCase.ExecuteAsync(request);

        return Ok(result);
    }
}