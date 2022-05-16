namespace QZI.User.Domain.User.Services.Requests
{
    public class CreateIdentityUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public static CreateIdentityUserRequest Create(string email, string password) =>
            new CreateIdentityUserRequest {Email = email, Password = password, ConfirmPassword = password};
    }
}
