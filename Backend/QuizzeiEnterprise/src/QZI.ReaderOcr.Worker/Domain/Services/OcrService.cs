using System.Diagnostics;
using QZI.ReaderOcr.Worker.Domain.Services.Abstractions;

namespace QZI.ReaderOcr.Worker.Domain.Services
{
    public class OcrService : IOcrService
    {
        public async Task ExecuteOcr(string inputPdfFileName, string outputTextFileName)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };
            process.StartInfo = startInfo;

            process.Start();
            await SendOcrCommandToCmd(inputPdfFileName, outputTextFileName, process);
            process.Close();
        }

        private static async Task SendOcrCommandToCmd(string inputPdfFileName, string outputTextFileName, Process process)
        {
            await process.StandardInput.WriteLineAsync($"ocrmypdf --sidecar files/{outputTextFileName}.txt files/{inputPdfFileName}.pdf files/output_{inputPdfFileName}.pdf --force-ocr");
        }
    }
}
