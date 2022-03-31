using System;

namespace QZI.User.Domain.User.Entities
{
    public class PersonalUser
    {
        public Guid UserUuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int ProfileId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public virtual Profile Profile { get; set; }

        public static PersonalUser CreateNewUser(string name, string email, string password, int profileId)
        {
            return new PersonalUser()
            {
                UserUuid = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password,
                Active = true,
                ProfileId = profileId,
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            };
        }
    }
}
