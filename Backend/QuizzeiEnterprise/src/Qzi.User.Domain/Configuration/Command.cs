﻿using System;
using FluentValidation.Results;
using MediatR;

namespace QZI.User.Domain.Configuration
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
