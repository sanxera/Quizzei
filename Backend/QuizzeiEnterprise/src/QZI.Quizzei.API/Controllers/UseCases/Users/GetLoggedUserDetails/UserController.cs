using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Users.GetLoggedUserDetails;

[Route("api/users")]
public class UserController : MainController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _userService = userService;
    }

    [HttpGet("get-logged-user-details")]
    public async Task<IActionResult> GetLoggedUserDetails()
    {
        var email = ReadEmailFromToken();

        var user = await _userService.GetUserAsync(email);

        return Ok(user);
    }
}