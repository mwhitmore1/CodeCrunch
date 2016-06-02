using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class ModuleQuestion
    {
        //Primary Key
        public int ModuleQuestionId { get; set; }

        //Foreign Key
        public int ModuleId { get; set; }
        public string UserId { get; set; }

        //Other fields related to model
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }


        //Relationships
        public virtual User User { get; set; }
        public virtual Module Module { get; set; }
        public virtual ModuleAnswer ModuleAnswer { get; set; }
    }
}