namespace QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr.Interfaces;

public interface IOcrService
{
    Task ExecuteOcr(string inputPdfFileName, string outputTextFileName);
}