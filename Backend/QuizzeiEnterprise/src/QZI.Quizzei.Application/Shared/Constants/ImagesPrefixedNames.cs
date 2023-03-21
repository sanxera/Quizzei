namespace QZI.Quizzei.Application.Shared.Constants;

public static class ImagesPrefixedNames
{
    public const string Image1 = "Image1.png";
    public const string Image2 = "Image2.png";
    public const string Image3 = "Image3.png";
    public const string Image4 = "Image4.png";
    public const string Image5 = "Image5.png";
    public const string Image6 = "Image6.png";

    public static string[] GetAllImages() =>
        new[]
        {
            Image1,
            Image2,
            Image3,
            Image4,
            Image5,
            Image6,
        };
}