using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace CodeCrunch.API.Models
{
    public class Bootcamp : User
    {

        public Bootcamp()
        {
            Perks = new Collection<Perk>();
            Tracks = new Collection<Track>();
            Modules = new Collection<Module>();
            Languages = new Collection<Language>();
        }

        // Primary key to be inherited from User
        // Foriegn keys - none

        //Other fields related to model
        // Email, phone, and ConfirmEmail stored in user table.
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
    }
}