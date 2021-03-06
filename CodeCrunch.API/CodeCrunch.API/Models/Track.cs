﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace CodeCrunch.API.Models
{
    public class Track
    {

        public Track()
        {
            Languages = new Collection<Language>();
            Modules = new Collection<Module>();
            EnrolledStudents = new Collection<Student>();
        }

        // Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }

        public string TrackName { get; set; }
        public string Description { get; set; }

        // Foriegn keys
        // The id of the creator and owner
        public string BootcampId { get; set; }
        
        // Not sure what this is
        public int SearchBootcamp { get; set; }

        // Relationships
        public virtual Bootcamp Bootcamp { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Student> EnrolledStudents { get; set; }        
    }
}