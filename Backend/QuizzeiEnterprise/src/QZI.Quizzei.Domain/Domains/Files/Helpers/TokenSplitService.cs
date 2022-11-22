using System.Collections.Generic;
using System.Linq;
using QZI.Quizzei.Domain.Domains.Files.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Files.Helpers
{
    public class TokenSplitService : ITokenSplitService
    {
        public string[] SplitQuestionToken(int tokenSize)
        {
            var tokens = new List<string>();

            for (var i = 0; i < tokenSize; i++)
            {
                tokens.Add($"[{i}]");
            }

            return tokens.ToArray();
        }

        public string[] SplitOptionsToken()
        {
            var alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

            return alpha.Select(t => $"[{t}]").ToArray();
        }
    }
}
