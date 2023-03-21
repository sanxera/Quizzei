using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Models.Response;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr.Interfaces;

namespace QZI.Quizzei.Application.UseCases.Files.ReadPdf;

public class ReadPdfUseCase : IReadPdfUseCase
{
    private readonly ITokenSplitService _tokenSplitService;
    private readonly IOcrService _ocrService;

    public ReadPdfUseCase(ITokenSplitService tokenSplitService, IOcrService ocrService)
    {
        _tokenSplitService = tokenSplitService;
        _ocrService = ocrService;
    }

    public async Task<GetOcrQuestionsWithOptionsByQuizResponse> ExecuteAsync(Stream stream, string fileName)
    {
        ConvertStreamToLocalPdf(stream, fileName);

        await _ocrService.ExecuteOcr(fileName, "output");

        var fileInput = await File.ReadAllTextAsync("output.txt");

        var questionToken = _tokenSplitService.SplitQuestionToken(99);
        var splittedQuestion = fileInput.Split(questionToken, StringSplitOptions.None).ToList();

        var optionToken = _tokenSplitService.SplitOptionsToken();

        var response = new GetOcrQuestionsWithOptionsByQuizResponse();

        foreach (var questionString in splittedQuestion)
        {
            var firstQuestionRange = questionString.IndexOf("[a]", StringComparison.Ordinal);

            if (firstQuestionRange <= 0)
                continue;

            var formattedOptions = questionString[firstQuestionRange..];

            var formattedQuestion = questionString[..firstQuestionRange];
            var splittedOptions = formattedOptions.Split(optionToken, StringSplitOptions.RemoveEmptyEntries);

            var questionResponse = OcrQuestionResponse.Create(TrimString(formattedQuestion));
            foreach (var option in splittedOptions)
            {
                var optionsResponse = OcrQuestionOptionResponse.Create(TrimString(option));
                questionResponse.Options.Add(optionsResponse);
            }

            response.Questions.Add(questionResponse);
        }

        return response;
    }

    private static string TrimString(string value)
    {
        return value.Trim().Replace("\r", "").Replace("\n", "");
    }

    private static void ConvertStreamToLocalPdf(Stream stream, string fileName)
    {
        var fileStream = File.Create(fileName);
        stream.Seek(0, SeekOrigin.Begin);
        stream.CopyTo(fileStream);
        fileStream.Close();
    }
}