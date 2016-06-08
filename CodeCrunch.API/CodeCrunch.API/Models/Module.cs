using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class Module
    {
        // Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; }

        // Foriegn keys
        // creator of the module
        public string BootcampId { get; set; }      
        
        // Properties
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        // Relationships
        public virtual Bootcamp Bootcamp { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }

    }
}
