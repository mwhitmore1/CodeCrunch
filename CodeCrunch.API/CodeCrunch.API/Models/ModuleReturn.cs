using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class ModuleReturn
    {
        public string BootcampId { get; set; }      
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        // Relationships
        public Bootcamp Bootcamp { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public ICollection<ModuleQuestion> Questions { get; set; }
    }
}
