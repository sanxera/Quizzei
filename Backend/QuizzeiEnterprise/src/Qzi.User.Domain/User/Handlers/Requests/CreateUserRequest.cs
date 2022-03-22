namespace Qzi.User.Domain.User.Handlers.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ProfileId { get; set; }
    }
}
