using System.Threading.Tasks;
using QZI.Quiz.Domain.Quiz.Acl.Response;

namespace QZI.Quiz.Domain.Quiz.Acl.Interface
{
    public interface IUserServiceAcl
    {
        Task<GetUserByEmailResponse> GetUserIdByEmail(string email);
    }
}
