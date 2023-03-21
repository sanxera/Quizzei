namespace QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr.Interfaces;

public interface ITokenSplitService
{
    string[] SplitQuestionToken(int tokenSize);
    string[] SplitOptionsToken();
}