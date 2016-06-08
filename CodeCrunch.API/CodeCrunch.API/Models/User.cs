using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class User : IdentityUser
    {
        // Foreign keys
        public int? ProfilePictureId { get; set; }

        public string Description { get; set; }
        public string LinkedIn { get; set; }
        public string Blog { get; set; }

        // Relationships
        public virtual ICollection<ModuleQuestion> Questions { get; set; }
        public virtual ICollection<ModuleAnswer> Answers { get; set; }
        public virtual ProfilePicture ProfilePicture { get; set; }
    }
}