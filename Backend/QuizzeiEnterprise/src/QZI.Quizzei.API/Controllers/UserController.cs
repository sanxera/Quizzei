using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using NetDevPack.Identity.Model;
using QZI.Quizzei.Domain.Domains.User.Entities;
using QZI.Quizzei.Domain.Domains.User.Request;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;

namespace QZI.Quizzei.API.Controllers
{
    [Route("api/user")]
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

            return Ok(new { CreatedUserUuid = result });
        }

        [HttpPost("create-role")]
        public async Task<ActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var result = await _userService.CreateRole(request);

            return Ok(new { CreatedRoleUuid = result });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUser loginUser)
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
                return BadRequest("This user is blocked");
            }

            return Ok("Incorrect user or password");
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
}