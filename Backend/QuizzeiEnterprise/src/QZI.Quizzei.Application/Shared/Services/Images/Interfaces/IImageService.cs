namespace QZI.Quizzei.Application.Shared.Services.Images.Interfaces;

public interface IImageService
{
    Task<string> GetPrefixedImagesUrl(string imageName);
}