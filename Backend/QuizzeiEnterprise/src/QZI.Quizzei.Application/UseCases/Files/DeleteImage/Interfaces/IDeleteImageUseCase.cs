using QZI.Quizzei.Application.UseCases.Files.DeleteImage.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.DeleteImage.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.DeleteImage.Interfaces;

public interface IDeleteImageUseCase
{
    Task<DeleteImageResponse> ExecuteAsync(DeleteImageRequest request);
}