using QZI.Quizzei.Application.UseCases.Files.UploadImage.Models.Request;
using QZI.Quizzei.Application.UseCases.Files.UploadImage.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Files.UploadImage.Interfaces;

public interface IUploadImageUseCase
{
    Task<UploadImageResponse> ExecuteAsync(UploadImageRequest request);
}