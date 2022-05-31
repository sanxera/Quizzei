using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Acl.Response;

namespace QZI.Quiz.Domain.Quiz.Acl.Interface
{
    public interface ICategoryServiceAcl
    {
        Task<GetCategoryByIdResponse> GetCategoryById(int categoryId);
    }
}
