using QZI.Quizzei.Application.Shared.Enums;

namespace QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;

public interface IAmazonService
{
    Task<Stream> GetObjectAsync(string fileName, FileType fileType);
    Task<string> GetObjectUrl(string fileName, FileType fileType);
    Task UploadObjectAsync(string fileName, FileType fileType, Stream fileStream, string contentType);
    Task DeleteObjectAsync(string fileName, FileType fileType);
}