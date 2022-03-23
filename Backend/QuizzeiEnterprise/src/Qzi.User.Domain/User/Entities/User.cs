using System;
using System.Collections.Generic;

namespace QZI.User.Domain.User.Entities
{
    public partial class User
    {
        public User()
        {
            Answers = new HashSet<Answer>();
            Classrooms = new HashSet<Classroom>();
            QuizProcesses = new HashSet<QuizProcess>();
        }

        public Guid UserUuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int ProfileId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual ICollection<QuizProcess> QuizProcesses { get; set; }

        public static User CreateNewUser(string name, string password, string email, int profileId) => new User
        {
            UserUuid = Guid.NewGuid(),
            Name = name,
            Email = email,
            Password = password,
            Active = true,
            ProfileId = profileId,
            CreatedAt = DateTime.Now,
            CreatedBy = "System",
        };
    }
}
