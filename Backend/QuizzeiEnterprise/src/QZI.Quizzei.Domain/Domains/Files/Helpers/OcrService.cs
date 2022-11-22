using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Files.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Files.Helpers
{
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
}
