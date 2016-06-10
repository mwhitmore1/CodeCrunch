using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace CodeCrunch.API.Models
{
    public class Chapter
    {

        public Chapter()
        {
            CompletedChapterStudents = new Collection<Student>();
        }

        //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChapterId { get; set; }

        //Foreign Key
        public int ModuleId { get; set; }

        //Other fields related to model
        public bool CurrentChapter { get; set; }
        public string ChapterName { get; set; }
        public string ChapterDescription { get; set; }
        public int Likes { get; set; }
        
        //Relationships
        public virtual Module Module { get; set; }
        public virtual ICollection<Student> CompletedChapterStudents { get; set; }
    }
}