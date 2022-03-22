using System;
using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class Profile
    {
        public Profile()
        {
            Users = new HashSet<User>();
        }

        public int ProfileId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int PermissionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
