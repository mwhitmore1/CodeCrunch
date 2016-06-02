using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class Chapter
    {
            //Primary Key
            public int ChapterId { get; set; }

            //Foreign Key
            public int ModuleId { get; set; }

            //Other fields related to model
            public bool CurrentChapter { get; set; }
            public string ChapterName { get; set; }
            public string ChapterDescription { get; set; }

            //Relationships
            public Module Module { get; set; }
    }
}