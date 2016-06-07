using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace CodeCrunch.Core.Domain
{
    public class User : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        // Foreign keys
        public int? ProfilePictureId { get; set; }

        // Relationships
        public virtual ProfilePicture ProfilePicture { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
    }
}