using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class Enrollment
    {
        // Primary key
        public int EnrollmentID { get; set; }

        // Foreign keys
        public string StudentId { get; set; }
        public int TrackId { get; set; }

        // Relationships
        public virtual Student Student { get; set; }
        public virtual Track Track { get; set; }
    }
}