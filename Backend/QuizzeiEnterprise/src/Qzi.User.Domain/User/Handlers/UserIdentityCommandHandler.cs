using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Repositories;
using QZI.User.Domain.User.Services.Interfaces;

namespace QZI.User.Domain.User.Handlers
{
    public class UserIdentityCommandHandler :
        IRequestHandler<CreateUserCommand, CreateUserResponse>,
        IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly IAuthUserService _authUserService;
        private readonly IUserRepository _userRepository;

        public UserIdentityCommandHandler(IAuthUserService authUserService, IUserRepository userRepository)
        {
            _authUserService = authUserService;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            var userRegister = request.Request;
            var newUser = Entities.User.CreateNewUser(userRegister.Name, userRegister.Password, userRegister.Email, userRegister.ProfileId);
            var identityNewUser = CreateIdentityUserRequest.Create(userRegister.Email, userRegister.Password);

            await _userRepository.InsertNewUser(newUser);
            return await _authUserService.RegisterIdentityUser(identityNewUser);
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            return await _authUserService.Login(request.Request);
        }
    }
}
