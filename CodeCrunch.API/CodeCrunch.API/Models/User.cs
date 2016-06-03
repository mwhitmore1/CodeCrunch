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
        public virtual Student Student { get; set; }
        public virtual Bootcamp Bootcamp { get; set; }

        // Foreign keys
        public int? ProfilePictureId { get; set; }

        // Relationships
        public virtual ProfilePicture ProfilePicture { get; set; }
    }
}