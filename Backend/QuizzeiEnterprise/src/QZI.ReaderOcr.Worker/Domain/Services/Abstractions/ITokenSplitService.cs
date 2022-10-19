namespace QZI.ReaderOcr.Worker.Domain.Services.Abstractions
{
    public interface ITokenSplitService
    {
        string[] SplitQuestionToken(int tokenSize);
        string[] SplitOptionsToken();
    }
}
