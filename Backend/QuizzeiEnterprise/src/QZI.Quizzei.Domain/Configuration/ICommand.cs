using FluentValidation.Results;

namespace QZI.Quizzei.Domain.Configuration
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
