using QZI.Quizzei.Domain.Shared.Constants;
using QZI.Quizzei.Domain.Shared.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Shared.Enums;

namespace QZI.Quizzei.Domain.Shared.Services
{
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
}
