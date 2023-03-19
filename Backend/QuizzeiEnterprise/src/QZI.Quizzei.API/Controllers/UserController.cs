using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Model;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.User.Service.Request;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.API.Controllers;

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

    [HttpPost("create-user")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _userService.CreateUser(request);

        return Ok(new { Created = true, CreatedUserUuid = result });
    }

    [HttpPost("create-role")]
    public async Task<ActionResult> CreateRole([FromBody] CreateRoleRequest request)
    {
        var result = await _userService.CreateRole(request);

        return Ok(new { CreatedRoleUuid = result });
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginUser loginUser)
    {
        if (!ModelState.IsValid) return Ok(ModelState);

        var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);
             
        if (result.Succeeded)
        {
            var fullJwt = GetFullJwt(loginUser.Email);
            return Ok(new {Token = fullJwt, Logged = true});
        }

        if (result.IsLockedOut)
        {
            throw new GenericException("User is locked out !");
        }

        throw new GenericException("Email or password is wrong !");
    }

    [HttpPost("verify-user")]
    public async Task<IActionResult> VerifyUser()
    {
        return Ok(new { Verified = true });
    }

    [HttpGet("get-user-details")]
    public async Task<IActionResult> GetUserDetails(Guid userUuid)
    {
        var user = await _userService.GetUserDetails(new GetUserDetailsRequest { UserUuid = userUuid });

        if (user is null)
            return NotFound();

        return Ok(user);
    }


    [HttpGet("get-logged-user-details")]
    public async Task<IActionResult> GetLoggedUserDetails()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var user = await _userService.GetUserDetails(new GetLoggedUserDetailsRequest { Email = email });

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    private string GetFullJwt(string email)
    {
        return new JwtBuilder()
            .WithUserManager(_userManager)
            .WithJwtSettings(_appJwtSettings)
            .WithEmail(email)
            .WithJwtClaims()
            .WithUserClaims()
            .WithUserRoles()
            .BuildToken();
    }
}