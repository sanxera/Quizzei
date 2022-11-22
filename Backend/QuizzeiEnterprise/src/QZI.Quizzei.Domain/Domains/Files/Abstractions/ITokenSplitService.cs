namespace QZI.Quizzei.Domain.Domains.Files.Abstractions
{
    public interface ITokenSplitService
    {
        string[] SplitQuestionToken(int tokenSize);
        string[] SplitOptionsToken();
    }
}
