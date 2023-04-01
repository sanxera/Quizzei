namespace QZI.Quizzei.Application.Shared.Constants;

public static class ImagesPrefixedNames
{
    public const string Image1 = "image-database.png";
    public const string Image2 = "image-english-school.png";
    public const string Image3 = "image-mathematics.png";
    public const string Image4 = "image-pirate-story.png";
    public const string Image5 = "image-science.png";
    public const string Image6 = "Default.png";

    public static string[] GetAllImages() =>
        new[]
        {
            Image1,
            Image2,
            Image3,
            Image4,
            Image5,
            Image6
        };
}