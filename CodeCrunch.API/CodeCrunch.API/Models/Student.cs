using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class Student
    { 
        // Primary key
        public string StudentId { get; set; }
        
        public virtual User User { get; set; }

        // Email, phone, and ConfirmEmail stored in User table.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public string Description { get; set; }

        // not sure about data type
        public string Interests { get; set; }
        public string LinkedIn { get; set; }
        public string Blog { get; set; }
    }
}