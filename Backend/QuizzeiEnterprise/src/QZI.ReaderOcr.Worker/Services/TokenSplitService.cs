using QZI.ReaderOcr.Worker.Services.Abstractions;

namespace QZI.ReaderOcr.Worker.Services
{
    public class TokenSplitService : ITokenSplitService
    {
        public string[] SplitQuestionToken(int tokenSize)
        {
            var tokens = new List<string>();

            for (var i = 0; i < tokenSize; i++)
            {
                tokens.Add($"{i}.");
            }

            return tokens.ToArray();
        }

        public string[] SplitOptionsToken(int tokenSize)
        {
            var tokens = new List<string>();
            var alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (var i = 0; i < tokenSize; i++)
            {
                tokens.Add($"{alpha[0]}.");
            }
            return tokens.ToArray();
        }
    }
}
