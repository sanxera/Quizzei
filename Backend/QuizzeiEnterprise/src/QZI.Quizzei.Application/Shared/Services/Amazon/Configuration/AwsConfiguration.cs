namespace QZI.Quizzei.Application.Shared.Services.Amazon.Configuration;

public class AwsConfiguration
{
    public string AccessKey { get; set; } = null!;
    public string SecretAccessKey { get; set; } = null!;
    public string BucketName { get; set; } = null!;
}