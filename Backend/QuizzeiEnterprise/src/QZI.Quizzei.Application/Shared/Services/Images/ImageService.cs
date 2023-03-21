using QZI.Quizzei.Application.Shared.Constants;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Images.Interfaces;

namespace QZI.Quizzei.Application.Shared.Services.Images;

public class ImageService : IImageService
{
    private readonly IAmazonService _amazonService;

    public ImageService(IAmazonService amazonService)
    {
        _amazonService = amazonService;
    }

    public async Task<string> GetPrefixedImagesUrl(string imageName)
    {
        if (ImagesPrefixedNames.GetAllImages().All(x => x != imageName))
            return string.Empty;

        return await _amazonService.GetObjectUrl(imageName, FileType.Image);
    }
}