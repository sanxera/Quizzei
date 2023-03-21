using System.Diagnostics;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr.Interfaces;

namespace QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr;

public class OcrService : IOcrService
{
    public async Task ExecuteOcr(string inputPdfFileName, string outputTextFileName)
    {
        var path = Directory.GetCurrentDirectory();

        var process = new Process();
        var startInfo = new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = "cmd.exe",
            WorkingDirectory = path,
            Arguments = $"/c ocrmypdf --sidecar {outputTextFileName}.txt {inputPdfFileName} output_{inputPdfFileName} --force-ocr"
        };
        process.StartInfo = startInfo;

        process.Start();

        await Task.Delay(10000);
    }
}