using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.ReadPdf.Interfaces;

public interface IReadPdfUseCase
{
    Task<GetOcrQuestionsWithOptionsByQuizResponse> ExecuteAsync(Stream stream, string fileName);
}