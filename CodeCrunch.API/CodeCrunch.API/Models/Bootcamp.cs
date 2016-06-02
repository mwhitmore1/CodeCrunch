using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCrunch.API.Models
{
    public class Bootcamp : IdentityUser
    {
        // Primary key
        public string BootcampId { get; set; }
        
        public virtual User User { get; set; }
        // Email, phone, and ConfirmEmail stored in user table.
        public string BootcampName { get; set; }
        public string BootCampSite { get; set; }
        public string BootcampCity { get; set; }
        public string BootcampState { get; set; }
        public string Perks { get; set; }

        // Add tags

        // not sure about data type
        public string Interests { get; set; }

        public string LinkedIn { get; set; }
        public string Blog { get; set; }

        // Relationships
        public ICollection<Track> Tracks { get; set; }
        //not sure if this needs to be here
        public ICollection<Student> Students { get; set; }
    }
}