using QZI.Quizzei.Application.Shared.Constants;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.GetDefaultImages.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.GetDefaultImages.Models.Responses;

namespace QZI.Quizzei.Application.UseCases.Files.GetDefaultImages
{
    public class GetDefaultImagesUseCase : IGetDefaultImagesUseCase
    {
        private readonly IAmazonService _amazonService;

        public GetDefaultImagesUseCase(IAmazonService amazonService)
        {
            _amazonService = amazonService;
        }

        public async Task<GetDefaultImagesResponse> ExecuteAsync()
        {
            var response = new GetDefaultImagesResponse();

            foreach (var imageName in ImagesPrefixedNames.GetAllImages())
            {
                var imagePath = await _amazonService.GetObjectUrl(imageName, FileType.Image);
                var imageResponse = ImageResponse.Create(imageName, imagePath);

                response.DefaultImages.Add(imageResponse);
            }

            return response;
        }
    }
}
