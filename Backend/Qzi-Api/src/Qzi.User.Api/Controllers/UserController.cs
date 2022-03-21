using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qzi.User.Api.Controllers.Abstraction;

namespace Qzi.User.Api.Controllers
{
    [Route("api/users")]
    public class UserController : MainController
    {
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateNewUser()
        {
            return CustomResponse();
        }
    }
}
