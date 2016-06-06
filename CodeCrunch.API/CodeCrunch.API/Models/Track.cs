using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string BootcampId { get; set; }

        // May need to be changed
        public string CreatorName { get; set; }

        // Not sure what this is
        public int SearchBootcamp { get; set; }

        // Relationships
        public virtual Bootcamp Bootcamp { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Student> EnrolledStudents { get; set; }        
    }
}