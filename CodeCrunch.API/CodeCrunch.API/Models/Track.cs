﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Design;

namespace CodeCrunch.API.Models
{
    public class Track
    {
        // Primary key
        public int TrackId { get; set; }

        public string TrackName { get; set; }
        public string Description { get; set; }

        // Foriegn keys
        public string StudentId { get; set; }
        public int ModuleId { get; set; }
        public int BootcampId { get; set; }

        // May need to be changed
        public string CreatorName { get; set; }

        // Relationships
        public Module Modules { get; set; }

        // Not sure what this is
        public int SearchBootcamp { get; set; }
    }
}