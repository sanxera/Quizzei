using QZI.Quizzei.Application.UseCases.Files.GetDefaultImages.Models.Responses;

namespace QZI.Quizzei.Application.UseCases.Files.GetDefaultImages.Interfaces
{
    public interface IGetDefaultImagesUseCase
    {
        Task<GetDefaultImagesResponse> ExecuteAsync();
    }
}
