using FluentValidation.Results;

namespace QZI.Question.Domain.Configuration
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
