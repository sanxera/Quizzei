using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Requests;

namespace QZI.User.API.Controllers
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
        {
            var command = new LoginUserCommand(loginUserRequest);

            var result = await _mediator.Send(command);
            
            return CustomResponse(result);
        }

        [HttpPost("get-by-email")]
        public async Task<IActionResult> GetUserByEmail([FromHeader] string email)
        {
            var command = new GetUserByEmailCommand(new GetUserByEmailRequest{Email = email});

            var result = await _mediator.Send(command);

            return CustomResponse(result);
        }
    }
}
