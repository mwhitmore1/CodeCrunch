using System.Collections.Generic;

namespace CodeCrunch.Core.Domain
{
    public class Bootcamp : User
    {
        // Primary key
        public int BootcampId { get; set; }

        //ForeignKey

        //Other fields related to model
        // Email, phone, and ConfirmEmail stored in user table.
        public string BootcampName { get; set; }
        public string BootcampSite { get; set; }
        public string BootcampCity { get; set; }
        public string BootcampState { get; set; }
        public string LinkedIn { get; set; }
        public string Blog { get; set; }

        // flesh out eventually
        public string Perks { get; set; }

        // Add tags here

        // not sure about data type
        public object Interests { get; set; }

        
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public string Email { get; set; }
        //public virtual User User { get; set; }
    }
}