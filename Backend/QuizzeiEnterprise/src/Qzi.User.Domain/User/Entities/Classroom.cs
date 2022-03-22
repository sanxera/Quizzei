using System;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class Classroom
    {
        public Guid ClassroomUuid { get; set; }
        public string Description { get; set; }
        public Guid UserOwnerUuid { get; set; }
        public int CourseId { get; set; }
        public int Active { get; set; }
        public int CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Course Course { get; set; }
        public virtual User UserOwnerUu { get; set; }
    }
}
