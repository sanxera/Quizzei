using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr.Interfaces;

namespace QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr;

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