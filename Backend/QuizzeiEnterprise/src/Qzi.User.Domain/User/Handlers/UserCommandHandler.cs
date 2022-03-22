using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qzi.User.Domain.User.Handlers.Commands;
using Qzi.User.Domain.User.Handlers.Responses;

namespace Qzi.User.Domain.User.Handlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        public Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
