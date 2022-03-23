using FluentValidation.Results;

namespace QZI.User.Domain.Configuration
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
