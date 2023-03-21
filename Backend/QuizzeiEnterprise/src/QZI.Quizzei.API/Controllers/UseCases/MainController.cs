using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace QZI.Quizzei.API.Controllers.UseCases;

public abstract class MainController : Controller
{
    private readonly IHttpContextAccessor _contextAccessor;

    protected MainController(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    protected string ReadEmailFromToken()
    {
        var jwt = _contextAccessor.HttpContext!.Request.Headers["Authorization"][0]!.Replace("Bearer ", string.Empty);

        var key = Encoding.ASCII.GetBytes("MYSECRETSUPERSECRET");
        var handler = new JwtSecurityTokenHandler();
        var validations = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        var claims = handler.ValidateToken(jwt, validations, out var tokenSecure);
        var email = claims.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        return email;
    }
}