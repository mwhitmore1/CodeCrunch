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

        //Other fields related to model
        // Email, phone, and ConfirmEmail stored in user table.
        public string BootcampName { get; set; }
        public string BootCampSite { get; set; }
        public string BootcampCity { get; set; }
        public string BootcampState { get; set; }
        // flesh out eventually
        public string Perks { get; set; }

        // Add tags here

        // not sure about data type
        public object Interests { get; set; }

        public string LinkedIn { get; set; }
        public string Blog { get; set; }

        // Relationships
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual virtual User User { get; set; }
    }
}