using System.Threading.Tasks;

namespace QZI.Quizzei.Domain.Shared.Interfaces;

public interface IImageService
{
    Task<string> GetPrefixedImagesUrl(string imageName);
}