using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;

namespace Qzi.User.Domain.Configuration
{
    public abstract class Command<TResponse> : ICommand, IRequest<TResponse>
    {
        protected Command()
        {
            MessageTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public long MessageTimestamp { get; private set; }
        public abstract ValidationResult ValidationResult { get; }
        public bool IsValid => ValidationResult.IsValid;
    }
}
