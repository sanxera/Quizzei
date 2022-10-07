namespace QZI.ReaderOcr.Worker.Services.Abstractions
{
    public interface IOcrService
    {
        Task ExecuteOcr(string inputPdfFileName, string outputTextFileName);
    }
}
