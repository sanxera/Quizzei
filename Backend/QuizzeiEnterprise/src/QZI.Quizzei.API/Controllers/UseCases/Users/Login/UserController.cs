using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Model;
using QZI.Quizzei.Application.Shared.Exceptions;

namespace QZI.Quizzei.API.Controllers.UseCases.Users.Login;

[Route("api/users")]
public class UserController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppJwtSettings _appJwtSettings;

    public UserController(SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppJwtSettings> appJwtSettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _appJwtSettings = appJwtSettings.Value;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginUser loginUser)
    {
        if (!ModelState.IsValid) return Ok(ModelState);

        var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

        if (result.Succeeded)
        {
            var fullJwt = GetFullJwt(loginUser.Email);
            return Ok(new { Token = fullJwt, Logged = true });
        }

        if (result.IsLockedOut)
        {
            throw new GenericException("User is locked out !");
        }

        throw new GenericException("Email or password is wrong !");
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