using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class Course
    {
        public Course()
        {
            Classrooms = new HashSet<Classroom>();
        }

        public int CourseId { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public int CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
