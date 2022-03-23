using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Services.Interfaces;

namespace QZI.User.Domain.User.Handlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>, IRequestHandler<UserLoginCommand, UserLoginResponse>
    {
        private readonly IAuthUserService _authUserService;

        public UserCommandHandler(IAuthUserService authUserService)
        {
            _authUserService = authUserService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRegister = request.Request;
            var newUser = Entities.User.CreateNewUser(userRegister.Name, userRegister.Password, userRegister.Email, userRegister.ProfileId);

            await _userRepository.InsertNewUser(newUser);
            return new CreateUserResponse();
        }

        public async Task<UserLoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return await _authUserService.Login(request.Request);
        }
    }
}
