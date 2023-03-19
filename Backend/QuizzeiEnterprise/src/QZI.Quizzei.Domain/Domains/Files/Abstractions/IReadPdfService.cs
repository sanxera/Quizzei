using System.IO;
using System.Threading;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Files.Responses;

namespace QZI.Quizzei.Domain.Domains.Files.Abstractions;

public interface IReadPdfService
{
    Task<GetOcrQuestionsWithOptionsByQuizResponse> ExecuteAsync(Stream stream, string fileName, CancellationToken stoppingToken);
}