using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Users.GetUserDetails;

[Route("api/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("get-user-details")]
    public async Task<IActionResult> GetUserDetails(Guid userUuid)
    {
        var user = await _userService.GetUserAsync(userUuid);

        return Ok(user);
    }
}