using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;

namespace QZI.Quizzei.API.Controllers.UseCases.Users.GetLoggedUserDetails;

[Route("api/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppJwtSettings _appJwtSettings;

    public UserController(SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppJwtSettings> appJwtSettings, IUserService userService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _userService = userService;
        _appJwtSettings = appJwtSettings.Value;
    }

    [HttpGet("get-logged-user-details")]
    public async Task<IActionResult> GetLoggedUserDetails()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var user = await _userService.GetUserAsync(email);

        return Ok(user);
    }
}