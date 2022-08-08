 using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Core.Exceptions;
using QZI.User.Domain.User.Entities;
using QZI.User.Domain.User.Exceptions;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Repositories;
using QZI.User.Domain.User.Services.Interfaces;
using QZI.User.Domain.User.Services.Requests;

namespace QZI.User.Domain.User.Handlers
{
    public class UserIdentityCommandHandler :
        IRequestHandler<CreateUserCommand, CreateUserResponse>,
        IRequestHandler<LoginUserCommand, LoginUserResponse>,
        IRequestHandler<GetUserByEmailCommand, GetUserByEmailResponse>
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
            var newUser = PersonalUser.CreateNewUser(userRegister.Name, userRegister.Email, userRegister.Password, userRegister.ProfileId);
            var identityNewUser = CreateIdentityUserRequest.Create(userRegister.Email, userRegister.Password);

            try
            {
                await CheckIfUserAlreadyCreated(newUser.Email);

                await _userRepository.InsertNewUser(newUser);
                return await _authUserService.RegisterIdentityUser(identityNewUser);
            }
            catch (Exception ex)
            {
                throw new CreateUserException(ex.Message, ex);
            }
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            return await _authUserService.Login(request.Request);
        }

        public async Task<GetUserByEmailResponse> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            var user = await _userRepository.FindUserByEmail(request.Request.Email);

            if (user == null)
                throw new NotFoundException("User not found");

            return new GetUserByEmailResponse { Id = user.UserUuid, Name = user.Name };
        }

        private async Task CheckIfUserAlreadyCreated(string email)
        {
            var user = await _userRepository.FindUserByEmail(email);

            if (user is not null)
            {
                throw new UserAlreadyCreated("PersonalUser already created");
            }
        }
    }
}
