namespace QZI.ReaderOcr.Worker.Domain.Services.Abstractions;

public interface IOcrService
{
    Task ExecuteOcr(string inputPdfFileName, string outputTextFileName);
}