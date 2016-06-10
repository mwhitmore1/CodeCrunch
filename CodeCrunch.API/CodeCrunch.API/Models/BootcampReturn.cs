using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCrunch.API.Models
{
    public class BootcampReturn
    {
        //Bootcamp specific
        public string BootcampName { get; set; }
        public string BootcampSite { get; set; }
        public string BootcampCity { get; set; }
        public string BootcampState { get; set; }
        public string BootcampAddress { get; set; }
        
        // Relationships
        public virtual ICollection<Perk> Perks { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Language> Languages { get; set; }

        // inherifted from user
        public int? ProfilePictureId { get; set; }

        public string Description { get; set; }
        public string LinkedIn { get; set; }
        public string Blog { get; set; }

        // Relationships
        public virtual ICollection<ModuleQuestion> Questions { get; set; }
        public virtual ICollection<ModuleAnswer> Answers { get; set; }
        public virtual ProfilePicture ProfilePicture { get; set; }

        // inherited from IdentityUser
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}