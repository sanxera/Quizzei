using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qzi.User.Domain.User.Handlers.Commands;
using Qzi.User.Domain.User.Handlers.Requests;

namespace Qzi.User.Api.Controllers
{
    [Route("api/users")]
    public class UserController : MainController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateNewUser([FromBody] CreateUserRequest createUserRequest)
        {
            var command = new CreateUserCommand(createUserRequest);

            var result = await _mediator.Send(command);

            return CustomResponse(result);
        }
    }
}
