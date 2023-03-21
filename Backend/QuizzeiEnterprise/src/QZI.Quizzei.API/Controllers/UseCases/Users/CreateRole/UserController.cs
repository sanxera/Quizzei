using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QZI.Quizzei.Application.UseCases.Users.CreateRole.Interfaces;
using QZI.Quizzei.Application.UseCases.Users.CreateRole.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.Users.CreateRole;

[Route("api/users")]
public class UserController : Controller
{
    private readonly ICreateRoleUseCase _useCase;

    public UserController(ICreateRoleUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("create-role")]
    public async Task<ActionResult> CreateRole([FromBody] CreateRoleRequest request)
    {
        var result = await _useCase.ExecuteAsync(request);

        return Ok(new { CreatedRoleUuid = result });
    }
}