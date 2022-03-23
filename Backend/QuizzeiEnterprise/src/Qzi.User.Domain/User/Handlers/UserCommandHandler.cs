using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Repositories;

namespace QZI.User.Domain.User.Handlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRegister = request.Request;
            var newUser = Entities.User.CreateNewUser(userRegister.Name, userRegister.Password, userRegister.Email, userRegister.ProfileId);

            await _userRepository.InsertNewUser(newUser);
            return new CreateUserResponse();
        }
    }
}
