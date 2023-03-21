namespace QZI.Quizzei.Application.UseCases.Files.GetDefaultImages.Models.Responses;

public class GetDefaultImagesResponse
{
    public IList<ImageResponse> DefaultImages { get; set; } = new List<ImageResponse>();
}

public class ImageResponse
{
    public string ImageName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public static ImageResponse Create(string imageName, string imageUrl) 
        => new() { ImageName = imageName, ImageUrl = imageUrl };
}