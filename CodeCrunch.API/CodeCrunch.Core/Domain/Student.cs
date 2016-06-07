using System.Collections.Generic;

namespace CodeCrunch.Core.Domain
{
    public class Student : User
    { 
        // Primary key
        public int StudentId { get; set; }

        //Other fields related to model
        // Email, phone, and ConfirmEmail stored in User table.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        // not sure about data type
        public string Interests { get; set; }
        public string LinkedIn { get; set; }
        public string Blog { get; set; }

        // Relationships
        //public virtual User User { get; set; }
        public virtual ICollection<Track> EnrolledTracks { get; set; }
        public virtual ICollection<Chapter> CompletedChapters { get; set; }
    }
}