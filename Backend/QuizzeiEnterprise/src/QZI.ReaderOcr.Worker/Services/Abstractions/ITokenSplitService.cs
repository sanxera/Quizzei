namespace QZI.ReaderOcr.Worker.Services.Abstractions
{
    public interface ITokenSplitService
    {
        string[] SplitQuestionToken(int tokenSize);
        string[] SplitOptionsToken(int tokenSize);
    }
}
