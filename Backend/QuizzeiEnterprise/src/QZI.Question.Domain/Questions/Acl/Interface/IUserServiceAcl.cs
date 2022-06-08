using System.Threading.Tasks;
using QZI.Question.Domain.Questions.Acl.Response;

namespace QZI.Question.Domain.Questions.Acl.Interface
{
    public interface IUserServiceAcl
    {
        Task<GetUserByEmailResponse> GetUserIdByEmail(string email);
    }
}
