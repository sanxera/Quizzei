using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QZI.Core.Abstract;
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

            if (result.Created) return CustomResponse(result);

            foreach (var error in result.ResponseResult.Errors.Messages)
            {
                AddError(error);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
        {
            var command = new LoginUserCommand(loginUserRequest);

            var result = await _mediator.Send(command);
            
            return CustomResponse(result);

            foreach (var error in result.ResponseResult.Errors.Messages)
            {
                AddError(error);
            }

            return CustomResponse();
        }
    }
}
