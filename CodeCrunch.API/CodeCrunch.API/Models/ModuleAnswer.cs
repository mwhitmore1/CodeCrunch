using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class ModuleAnswer
    {
        //Primary Key
        public int ModuleAnswerId { get; set; }

        //Foreign Key
        public int ModuleQuestionId { get; set; }
        public string UserId { get; set; }

        //Other fields related to model
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }

        //Relationships
        public virtual User User { get; set; }
        public virtual ModuleQuestion ModuleQuestion { get; set; }
    }
}