using FluentValidation.Results;

namespace QZI.Quiz.Domain.Configuration
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
