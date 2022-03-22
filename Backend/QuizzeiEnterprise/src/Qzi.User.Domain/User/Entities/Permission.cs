using System;
using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            Profiles = new HashSet<Profile>();
        }

        public int PermissionId { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
