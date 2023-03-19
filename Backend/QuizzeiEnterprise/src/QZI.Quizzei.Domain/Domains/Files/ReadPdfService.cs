using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Files.Abstractions;
using QZI.Quizzei.Domain.Domains.Files.Responses;

namespace QZI.Quizzei.Domain.Domains.Files;

public class ReadPdfService : IReadPdfService
{
    private readonly ITokenSplitService _tokenSplitService;
    private readonly IOcrService _ocrService;

    public ReadPdfService(ITokenSplitService tokenSplitService, IOcrService ocrService)
    {
        _tokenSplitService = tokenSplitService;
        _ocrService = ocrService;
    }

    public async Task<GetOcrQuestionsWithOptionsByQuizResponse> ExecuteAsync(Stream stream, string fileName, CancellationToken stoppingToken)
    {
        ConvertStreamToLocalPdf(stream, fileName);

        await _ocrService.ExecuteOcr(fileName, "output");

        var fileInput = await File.ReadAllTextAsync("output.txt", stoppingToken);

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

            var questionResponse = new OcrQuestionResponse(TrimString(formattedQuestion));
            foreach (var option in splittedOptions)
            {
                var optionsResponse = new OcrQuestionOptionResponse(TrimString(option));
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