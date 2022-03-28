using QZI.Core.Communication;

namespace QZI.User.Domain.User.Handlers.Responses
{
    public class LoginUserResponse
    {
        public string Token { get; set; }
        public bool Logged { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }
}
