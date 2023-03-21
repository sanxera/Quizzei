using System.Text.RegularExpressions;
using Microsoft.Extensions.Hosting;
using QZI.ReaderOcr.Worker.Domain.Abstractions.UnitOfWork;
using QZI.ReaderOcr.Worker.Domain.Entities;
using QZI.ReaderOcr.Worker.Domain.Repositories;
using QZI.ReaderOcr.Worker.Domain.Services.Abstractions;

namespace QZI.ReaderOcr.Worker;

public class Worker : BackgroundService
{
    private readonly IHostApplicationLifetime _applicationLifetime;

    private readonly ITokenSplitService _tokenSplitService;
    private readonly IOcrService _ocrService;

    private readonly IOcrQuestionRepository _ocrQuestionRepository;
    private readonly IOcrQuestionOptionRepository _questionOptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public Worker(IHostApplicationLifetime applicationLifetime, ITokenSplitService tokenSplitService, IOcrService ocrService, IOcrQuestionRepository ocrQuestionRepository, IOcrQuestionOptionRepository questionOptionRepository, IUnitOfWork unitOfWork)
    {
        _applicationLifetime = applicationLifetime;
        _tokenSplitService = tokenSplitService;
        _ocrService = ocrService;
        _ocrQuestionRepository = ocrQuestionRepository;
        _questionOptionRepository = questionOptionRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _ocrService.ExecuteOcr("provafake", "output");

        var fileInput = await File.ReadAllTextAsync("Files/output.txt", stoppingToken);

        var questionToken = _tokenSplitService.SplitQuestionToken(99);
        var splittedQuestion = fileInput.Split(questionToken, StringSplitOptions.None).ToList();

        var optionToken = _tokenSplitService.SplitOptionsToken();

        foreach (var questionString in splittedQuestion)
        {
            var firstQuestionRange = questionString.IndexOf("[a]", StringComparison.Ordinal);

            if (firstQuestionRange <= 0)
                continue;

            var formattedOptions = questionString[firstQuestionRange..];
            var formattedQuestion = questionString[..firstQuestionRange];

            var options = formattedOptions
                .Split(optionToken, StringSplitOptions.RemoveEmptyEntries);

            await InsertQuestionWithOptions(formattedQuestion, options);
        }

        await _unitOfWork.SaveChangesAsync();
        _applicationLifetime.StopApplication();
    }

    private async Task InsertQuestionWithOptions(string questionText, string[] optionsText)
    {
        var ocrQuestion = new OcrQuestion(RemoveEmptySpaces(questionText));

        foreach (var optionText in optionsText)
        {
            var ocrOption = new OcrQuestionOption(RemoveEmptySpaces(optionText), CheckIfCorrectOption(optionText));
            ocrQuestion.Options.Add(ocrOption);
        }

        await _ocrQuestionRepository.AddAsync(ocrQuestion);
    }

    private string RemoveEmptySpaces(string text)
    {
        return Regex.Replace(text, @"\r\n?|\n", "");
    }

    private static bool CheckIfCorrectOption(string optionText)
    {
        return optionText.Contains("[CRO]");
    }
}