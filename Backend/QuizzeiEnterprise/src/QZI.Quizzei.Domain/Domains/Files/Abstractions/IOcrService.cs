using System.Threading.Tasks;

namespace QZI.Quizzei.Domain.Domains.Files.Abstractions;

public interface IOcrService
{
    Task ExecuteOcr(string inputPdfFileName, string outputTextFileName);
}