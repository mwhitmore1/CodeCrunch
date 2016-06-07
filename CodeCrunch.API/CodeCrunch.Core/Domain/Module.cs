using System.Collections.Generic;

namespace CodeCrunch.Core.Domain
{
    public class Module
    {
        // Primary key
        public int ModuleId { get; set; }

        // Foriegn keys
        public int TrackId { get; set; } 
        public string BootcampId { get; set; }      

        // May need to be changed
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        // Relationships
        //optional
        public virtual Bootcamp Bootcamp { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }

    }
}
