using System.IO;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Shared.Enums;

namespace QZI.Quizzei.Domain.Shared.Interfaces;

public interface IAmazonService
{
    Task<Stream> GetObjectAsync(string fileName, FileType fileType);
    Task<string> GetObjectUrl(string fileName, FileType fileType);
    Task UploadObjectAsync(string fileName, FileType fileType, Stream fileStream, string contentType);
}