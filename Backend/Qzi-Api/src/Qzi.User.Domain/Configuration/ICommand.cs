using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Qzi.User.Domain.Configuration
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
