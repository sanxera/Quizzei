using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Categories.Service.Requests;
using QZI.Quizzei.Domain.Domains.Categories.Service.Response;

namespace QZI.Quizzei.Domain.Domains.Categories.Service.Abstractions;

public interface ICategoryService
{
    Task<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request);
    Task<GetAllCategoriesResponse> GetAllCategories();
    Task<GetCategoryByIdResponse> GetCategoryById(int categoryId);
}