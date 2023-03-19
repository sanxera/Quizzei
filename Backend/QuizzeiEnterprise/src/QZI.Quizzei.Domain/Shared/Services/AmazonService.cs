using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3.Model;
using Amazon.S3;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Shared.Enums;
using QZI.Quizzei.Domain.Shared.Interfaces;

namespace QZI.Quizzei.Domain.Shared.Services;

public class AmazonService : IAmazonService
{
    private readonly AwsConfiguration _awsConfiguration;

    public AmazonService(AwsConfiguration awsConfiguration)
    {
        _awsConfiguration = awsConfiguration;
    }

    public async Task<Stream> GetObjectAsync(string fileName, FileType fileType)
    {
        var s3Client = new AmazonS3Client(_awsConfiguration.AccessKey, _awsConfiguration.SecretAccessKey, RegionEndpoint.SAEast1);
        var path = fileType == FileType.Document ? "Files/" : "Images/";

        var s3Request = new GetObjectRequest
        {
            BucketName = _awsConfiguration.BucketName,
            Key = $"{path + fileName}",
        };

        var response = await s3Client.GetObjectAsync(s3Request);

        return response.ResponseStream;
    }

    public Task<string> GetObjectUrl(string fileName, FileType fileType)
    {
        var s3Client = new AmazonS3Client(_awsConfiguration.AccessKey, _awsConfiguration.SecretAccessKey, RegionEndpoint.SAEast1);
        var path = fileType == FileType.Document ? "Files/" : "Images/";

        var s3Request = new GetPreSignedUrlRequest
        {
            BucketName = _awsConfiguration.BucketName,
            Key = $"{path + fileName}",
            Expires = DateTime.Now.AddHours(1)
        };

        var response = s3Client.GetPreSignedURL(s3Request);

        return Task.FromResult(response);
    }

    public async Task UploadObjectAsync(string fileName, FileType fileType, Stream fileStream, string contentType)
    {
        var s3Client = new AmazonS3Client(_awsConfiguration.AccessKey, _awsConfiguration.SecretAccessKey, RegionEndpoint.SAEast1);
        var path = fileType == FileType.Document ? "Files/" : "Images/";

        var s3Request = new PutObjectRequest
        {
            BucketName = _awsConfiguration.BucketName,
            Key = $"{path + fileName}",
            InputStream = fileStream,
            ContentType = contentType,
            CannedACL = S3CannedACL.BucketOwnerFullControl

        };

        await s3Client.PutObjectAsync(s3Request);
    }
}