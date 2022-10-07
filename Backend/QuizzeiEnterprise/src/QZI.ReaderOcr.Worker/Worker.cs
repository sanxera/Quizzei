using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using QZI.ReaderOcr.Worker.Services.Abstractions;

namespace QZI.ReaderOcr.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;

        private readonly ITokenSplitService _tokenSplitService;
        private readonly IOcrService _ocrService;

        public Worker(IHostApplicationLifetime applicationLifetime, ITokenSplitService tokenSplitService, IOcrService ocrService)
        {
            _applicationLifetime = applicationLifetime;
            _tokenSplitService = tokenSplitService;
            _ocrService = ocrService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _ocrService.ExecuteOcr("provafake", "output");

            var fileInput = await File.ReadAllTextAsync("output.txt", stoppingToken);

            var questionToken = _tokenSplitService.SplitQuestionToken(99);
            var splittedQuestion = fileInput.Split(questionToken, StringSplitOptions.None).ToList();

            var optionToken = _tokenSplitService.SplitOptionsToken(10);

            foreach (var questionString in splittedQuestion)
            {
                var options = questionString.Split(optionToken, StringSplitOptions.None);
            }


            _applicationLifetime.StopApplication();
        }
    }
}
