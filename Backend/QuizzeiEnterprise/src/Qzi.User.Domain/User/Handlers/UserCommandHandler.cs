using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Responses;

namespace QZI.User.Domain.User.Handlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        public Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
