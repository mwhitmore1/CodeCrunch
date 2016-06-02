using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class Module
    {
        // Primary key
        public int ModuleId { get; set; }

        // Foriegn keys
        public int TrackId { get; set; }       

        // May need to be changed
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        // Relationships
        public Chapter Chapter { get; set; }
        public TrackModule TrackModule { get; set; }
        public ModuleCompletion ModuleCompletion { get; set; }
        public ModuleQuestion ModuleQuestion { get; set; }

        //optional
        public Bootcamp Bootcamp { get; set; }

    }
}
}